using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour {

    public int HealthPotValue;
    public Health_System_Player PlayerHealth;

    private void Update()
    {
        if (Input.GetKeyDown("q") && UIManager.Potions>0)
        {
            PlayerHealth.CurrentHealth++;
            UIManager.Potions--;
        }
    }
}
