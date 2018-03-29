using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour {
    public Slider HealthBar;
    public Health_System_Enemies EnemyHealth;
	void Start () {
	}
	
	void Update () {
        HealthBar.maxValue = EnemyHealth.MaxHealth;
        HealthBar.value = EnemyHealth.Health;
	}
}
