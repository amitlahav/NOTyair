using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour 
{
    /*/<Summary>
     * When the Player enters the Enemy
     * Vision Sight - Vision Sight Biggens - Drop the patroling and starts chasing the player
     * as long as he's still in the Sight area
     * </Summary>
     * <Logic>
     * When Player enters the enemy vision sight BoxCollider2D trigger, This script gets activated
     * Checking the player's position and changing the Enemy's velocity according to that (Left or Right)
     * + if the Player's position on the Y axis is bigger than the enemies and the Player is not jumping -
     * Enemy jumps to avoid an obstacle
     * + if the Enemy is colliding with an object tagged "Wall" & is Chasing Player - Jump with current X axis velocity
     * </Logic>/*/

    public float speed;
    private Rigidbody2D rb;
    SpriteRenderer Sprite;
    Animator anim;
    public GameObject Slime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public void Update()// moving towoard player
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x < rb.position.x)
        {
            rb.velocity = new Vector2(-5 * speed, rb.velocity.y);
            anim.SetInteger("ChangeState", 1);
            Sprite.flipX = false;
        }
        else if(!(GameObject.FindGameObjectWithTag("Player").transform.position.x < rb.position.x))
        {
            rb.velocity = new Vector2(5 * speed, rb.velocity.y);
            anim.SetInteger("ChangeState",1);
            Sprite.flipX = true;
        }
        if (GameObject.FindGameObjectWithTag("Player").transform.position.y>rb.position.y&& GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y==0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3.2f * speed);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Slime.GetComponent<Enemy_Chase>().isActiveAndEnabled)
        {
            if (collision.gameObject.tag == "Wall" && GameObject.FindGameObjectWithTag("Player").transform.position.x != transform.position.x)
            {
                Slime.GetComponent<Rigidbody2D>().velocity = new Vector2(Slime.GetComponent<Rigidbody2D>().velocity.x, 3.2f * speed);
            }
        }
    }

}
