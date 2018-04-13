using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour {
    /*/<Summary>
     * Showing a HealthBar above the Enemy - displaying the enemy's Current Health and Missing Health
     * </Summary>
     * <Logic>
     * Displaying the Health integar from the Script with the Enemys Health
     * on a Slider
     * </Logic>/*/
    public Slider HealthBar;
    public Health_System_Enemies EnemyHealth;
	
	void Update () {
        HealthBar.maxValue = EnemyHealth.MaxHealth;
        HealthBar.value = EnemyHealth.Health;
	}
}
