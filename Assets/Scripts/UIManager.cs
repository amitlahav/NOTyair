using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    /*/<Summary>
     * Controlling the UI of the Player 
     * Healh bar - Ammo and magazine - weapon held - potions - score
     * Storing the amount of potions held
     * </Summary>
     * <Logic>
     * taking values from other scripts and presenting them on screen with texts Sliders and images
     * Score and potions value is stored here and only here
     * </Logic>*/

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

    public void Start()
    {
        Potions = 1;    
    }

    public void Update () {
        HealthBar.maxValue = playerHealth.MaxHealth;
        HealthBar.value = playerHealth.CurrentHealth;
        AmmoValue.text = "Ammo: "+HeldWeapon.Magazine+"/"+HeldWeapon.Ammo;
        GameScore.text = "Score: " + Score;
        WeaponSprite.sprite = WeaponImage.MainWeapon[WeaponImage.SelectedWeapon].gameObject.GetComponent<SpriteRenderer>().sprite;
        Potion_Inv.text = "X" + Potions; 
    }
}
