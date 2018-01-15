using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Player : MonoBehaviour {
    public int Health = 3;// Player Health Points
    public float invincibleTimeAfterHurt = 0.5f;
    private Rigidbody2D rb;
    Animation myanim;
    public float speed;
    public float push;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag=="Enemy"&& Health != 1)
        {
            Health--;
            Invincible(invincibleTimeAfterHurt);
            rb.AddForce(transform.up * speed);
            rb.AddForce(-transform.right * push);
        }
        else if (Health == 1)
        {
            Application.LoadLevel("Prototype");
            
        }

    }
    private void Invincible(float TimeInvincible)
    {
        while (true)
        {
            TimeInvincible -= Time.deltaTime;
            if (TimeInvincible < 0)
            {
                return;
            }
        }
    }
    
}
