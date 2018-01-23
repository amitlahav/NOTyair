using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Slider HealthBar;
    public Health_System_Player playerHealth;

	void Start () {
	  	
	}
	
	// Update is called once per frame
	void Update () {
        HealthBar.maxValue = playerHealth.MaxHealth;
        HealthBar.value = playerHealth.CurrentHealth;
	}
}
