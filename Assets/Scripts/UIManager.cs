using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Slider HealthBar;
    public Health_System_Player playerHealth;
    public Text AmmoValue;
    public Text GameScore;
    public WeaponSwitch HeldWeapon;
    public Image WeaponSprite;
    public WeaponSwitch WeaponImage;
    public static int Score;
    public void Start()
    {
    }
    public void Update () {
        HealthBar.maxValue = playerHealth.MaxHealth;
        HealthBar.value = playerHealth.CurrentHealth;
        AmmoValue.text = "Ammo: "+HeldWeapon.Magazine+"/"+HeldWeapon.Ammo;
        GameScore.text = "Score: " + Score;
        WeaponSprite.sprite = WeaponImage.MainWeapon[WeaponImage.SelectedWeapon].gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
