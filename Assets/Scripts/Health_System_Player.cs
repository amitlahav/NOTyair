using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health_System_Player : MonoBehaviour {
    /*/<Summary>
     * #When getting hit by an enemy -> remove 1 health from the player -> kick him back -> Set him unhittable for a period of time
     * #Keeping the Current Health of the player in boundry
     * #adding Health by Potions
     * </Summary>
     * <Logic>
     * when colliding with the BoxCollider2D of an Enemy Remove 1 from CurrentHealth and Invoke Invincibllity
     * if player presses "q" remove one of his potions and add him 1 health
     * </Logic>/*/
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
        if (Input.GetKeyDown("q") && UIManager.Potions > 0)
        {
            CurrentHealth++;
            UIManager.Potions--;
        }
    }
    void resetinvulnerability()
    {
        Invincible = false;
    }
}
