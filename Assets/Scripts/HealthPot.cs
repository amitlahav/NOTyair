using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour {
    /*/<Summary>
     * Picks up Potions from the floor
     * </Summary>
     * <Logic>
     * When Player Entering the BoxCollider2D Trigger of the potion - 
     * Destroy the Potion and add 1 to the UIManager [Inventory]
     * </Logic>*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.Potions++;
            Destroy(transform.gameObject);
        }
    }
}
