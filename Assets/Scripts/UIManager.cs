using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Slider HealthBar;
    public Health_System_Player playerHealth;
	void Update () {
        HealthBar.maxValue = playerHealth.MaxHealth;
        HealthBar.value = Health_System_Player.CurrentHealth;
	}
}
