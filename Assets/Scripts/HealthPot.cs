using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour {

    public int HealthPotValue;
    public Health_System_Player PlayerHealth;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player_Movement>() == null)
            return;
        if (Input.GetKeyDown("z"))
        {
            other.GetComponent<Health_System_Player>().CurrentHealth += HealthPotValue;
            Destroy(gameObject);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.GetComponent<Player_Movement>() == null)
             return;
         if (Input.GetKeyDown("z"))
         {
             PlayerHealth.CurrentHealth += HealthPotValue;
             Destroy(gameObject);
         }
     }
     private void OnTriggerExit2D(Collider2D other)
     {
         if (other.GetComponent<Player_Movement>() == null)
             return;
         if (Input.GetKeyDown("z"))
         {
            PlayerHealth.CurrentHealth += HealthPotValue;
             Destroy(gameObject);
         }
     }*/
}
