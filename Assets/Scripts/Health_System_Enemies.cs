using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemies : MonoBehaviour {
    public int MaxHealth;
    public int Health;
    Animator anim;
    Rigidbody2D rb;
    public AnimationClip DeathAnimation;
    public int Enemy_Score_Worth;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bolt")
        {
            Health -= collision.gameObject.GetComponent<Mover>().Damage;
            anim.SetTrigger("Hurt");
        }
        if (collision.gameObject.tag == "LeftBolt")
        {
            Health -= collision.gameObject.GetComponent<LeftMover>().Damage;
            anim.SetTrigger("Hurt");
        }
        if (Health <= 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Death();
        }
    }
    void HealthToRemove(int HealthToRemove)
    {
        Health -= HealthToRemove;
    }
    void Death()
    {
        anim.SetTrigger("Die");

        Destroy(rb.gameObject, DeathAnimation.length);
        UIManager.Score += Enemy_Score_Worth;
    }
}
