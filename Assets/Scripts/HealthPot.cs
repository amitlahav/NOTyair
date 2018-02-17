using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour {

    public int HealthPotValue;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player_Movement>() == null)
            return;
        if (Input.GetKeyDown("z"))
        {
            Health_System_Player.AddHealth(1);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player_Movement>() == null)
            return;
        if (Input.GetKeyDown("z"))
        {
            Health_System_Player.AddHealth(1);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player_Movement>() == null)
            return;
        if (Input.GetKeyDown("z"))
        {
            Health_System_Player.AddHealth(1);
            Destroy(gameObject);
        }
    }
}
