using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Slider HealthBar;
    public Health_System_Player playerHealth;
    public Text AmmoValue;
    public WeaponSwitch HeldWeapon;
    public void Start()
    {
    }
    public void Update () {
        HealthBar.maxValue = playerHealth.MaxHealth;
        HealthBar.value = playerHealth.CurrentHealth;
        AmmoValue.text = "Ammo: "+HeldWeapon.Magazine+"/"+HeldWeapon.Ammo;
	}
}
