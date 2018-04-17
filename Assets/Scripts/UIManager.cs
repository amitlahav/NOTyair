using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    /*/<Summary>
     * Controlling the UI of the Player 
     * Healh bar - Ammo and magazine - weapon held - potions - score - Time
     * Storing the amount of potions held
     * </Summary>
     * <Logic>
     * taking values from other scripts and presenting them on screen with texts Sliders and images
     * Score and potions value is stored here and only here
     * </Logic>*/

    public Text Timer;
    public Slider HealthBar;
    public Health_System_Player playerHealth;
    public Text AmmoValue;
    public Text GameScore;
    public WeaponSwitch HeldWeapon;
    public Image WeaponSprite;
    public WeaponSwitch WeaponImage;
    public Text Potion_Inv;
    public static int Potions;
    public static int Score;
    public static int Time_FromLoad;
    public static int Time_From_LastLoad;
    public static bool Moved_Scene = false;
    public static int ScoreRemoved;

    public void Start()
    {
        Potions = 1;    
    }
    
    public void Update () {
        Time_FromLoad = (int)Time.timeSinceLevelLoad - Time_From_LastLoad;
        Timer.text = "Time: " + Time_FromLoad;
        HealthBar.maxValue = playerHealth.MaxHealth;
        HealthBar.value = playerHealth.CurrentHealth;
        AmmoValue.text = "Ammo: "+HeldWeapon.Magazine+"/"+HeldWeapon.Ammo;
        GameScore.text = "Score: " + Score;
        WeaponSprite.sprite = WeaponImage.MainWeapon[WeaponImage.SelectedWeapon].gameObject.GetComponent<SpriteRenderer>().sprite;
        Potion_Inv.text = "X" + Potions;
        if (Moved_Scene)
        {
            if (Score != (ScoreRemoved - (Time_From_LastLoad * 10)))
            {
                Score--;
            }
            else
            {
                Moved_Scene = false;
            }
        }
    }
}
