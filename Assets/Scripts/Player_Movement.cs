using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    /*/<Summary>
     * Controling the Player's Movement with WASD
     * Going up and down a ladder
     * Death animation of the player
     * </Summary>
     * <Logic>
     * changing velocity of player depend on key pressed 
     * when health goes down to 0 set the death trigger on the animator
     * When Triggering a ladder's BoxCollider2D w and s change and now go up and down the ladder
     * </Logic>/*/

    const int RIGHT = 0, LEFT = 1;
    Transform Fist_Left;
    Transform Fist_Right;
    public float speed;
    private SpriteRenderer Player_Sprite;
    private Rigidbody2D rb;
    public float timechange;
    private float timestopanim;
    private float moveVelocity;
    private Animator anim;
    public Health_System_Player PlayerHealth;
    public static int LastKey = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player_Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (PlayerHealth.CurrentHealth == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetTrigger("Death");
        }
    }

    void FixedUpdate()
    {
        moveVelocity = 0f;
        if (Input.GetKey("d"))
        {
            moveVelocity = speed * 5;
            LastKey = 0;
            Player_Sprite.flipX = false;
        }
        if (Input.GetKey("a"))
        {
            moveVelocity = speed * -5;
            LastKey = 1;
            Player_Sprite.flipX = true;
        }
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        anim.SetFloat("Move", Input.GetAxisRaw("Horizontal"));
        if (Input.GetKey("w") && rb.velocity.y == 0)
        {   
            rb.velocity = new Vector2(rb.velocity.x, 3 * speed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            if (Input.GetKey("w"))
            {
                rb.velocity = new Vector2(0,2f*speed);  
                
            }
            if (Input.GetKey("s"))
            {
                rb.velocity = new Vector2(0, -3f * speed);
            }
        }
    }
}
