using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Player : MonoBehaviour {
    public int Health = 3;// Player Health Points
    public float invincibleTimeAfterHurt = 1.5f;
    Animation myanim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Enemy"&& Health != 1)
        {
            
        }  
    }
    
}
