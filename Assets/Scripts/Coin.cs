using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    /*/<Summary>
     * Touching the coin give 50 points
     * </Summary>
     * <Logic>
     * Player Entering the Coins BoxCollider2D Trigger
     * Destroy the coin and adds 50 points to the Score
     * On the UIManager
     * </Logic>/*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.Score += 50;
            Destroy(this.gameObject);
        }    
    }
}
