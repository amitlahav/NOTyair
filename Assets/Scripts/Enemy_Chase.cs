using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour 
{
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
