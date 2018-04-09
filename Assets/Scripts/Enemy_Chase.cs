using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour 
{
    public float speed;
    private Rigidbody2D rb;
    SpriteRenderer Sprite;
    Animator anim;
    public GameObject Player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    public void Update()// moving towoard player
    {
        if (Player.transform.position.x < rb.position.x)
        {
            rb.velocity = new Vector2(-5 * speed, rb.velocity.y);
            anim.SetInteger("ChangeState", 1);
            Sprite.flipX = false;
        }
        else if(!(Player.transform.position.x < rb.position.x))
        {
            rb.velocity = new Vector2(5 * speed, rb.velocity.y);
            anim.SetInteger("ChangeState",1);
            Sprite.flipX = true;
        }
        if (Player.transform.position.y>rb.position.y&& Player.GetComponent<Rigidbody2D>().velocity.y==0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3.2f * speed);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall"&& Player.transform.position.x >= transform.position.x)
        {
            Debug.Log("right");
            rb.velocity = new Vector2(rb.velocity.x, 3.2f * speed);
        }
        else if (collision.gameObject.tag == "Wall" && Player.transform.position.x <= transform.position.x)
        {
            Debug.Log("left");
            rb.velocity = new Vector2(rb.velocity.x, 3.2f * speed);
        }
    }

}
