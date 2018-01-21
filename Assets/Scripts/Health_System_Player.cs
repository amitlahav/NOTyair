using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health_System_Player : MonoBehaviour {
    public int Health = 3;// Player Health Points
    private Rigidbody2D rb;
    public float speed;
    public float push;

    public bool Invincible = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!Invincible)
        {
            if (collision.collider.gameObject.tag == "Enemy" && Health != 0)
            {
                Health--;
                HealthManager.RemoveHealth(1);
                if (Health != 0)
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
        if (Health == 0)
        SceneManager.LoadScene(Consts.PROTOTYPE);
    }
    void resetinvulnerability()
    {
        Invincible = false;
    }



}
