using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health_System_Player : MonoBehaviour {
    public int MaxHealth;// Player Health Points
    public int CurrentHealth;
    private Rigidbody2D rb;
    public float speed;
    public float push;
    public bool Invincible = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!Invincible)
        {
            if (collision.collider.gameObject.tag == "Enemy" && CurrentHealth != 0)
            {
                CurrentHealth--;           
                if (CurrentHealth != 0)
                {
                    rb.AddForce(transform.up * speed);
                    rb.AddForce(-transform.right * push);
                }
                Invincible = true;
                Invoke("resetinvulnerability", 1); 
            }       
        }
    }
    private void Update()
    {
        if (CurrentHealth>MaxHealth)
        CurrentHealth = MaxHealth;
        
    }
    void resetinvulnerability()
    {
        Invincible = false;
    }
}
