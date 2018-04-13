using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemies : MonoBehaviour {
    /*/<Summary>
     * if hit by a player's bolt - remove health from the enemy
     * when health lowers down than 0 - Death and Player recieves score
     * </Summary>
     * <Logic>
     * when hit by a bolt remove from the enemy the damage that bolt does - that damage comes from the WeaponBehaviour
     * upon Death Freezing the body of the Enemy -> Destroying the Enemy -> Adding Score to the Player 
     * </Logic>/*/
    public int MaxHealth;
    public int Health;
    Animator anim;
    Rigidbody2D rb;
    public AnimationClip DeathAnimation;
    public int Enemy_Score_Worth;
    bool Dead = false;
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
    }
    private void Update()
    {
        if (Health <= 0&&Dead == false)
        {
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Death();
            Dead = true;
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
