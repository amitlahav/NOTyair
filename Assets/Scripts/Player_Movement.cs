using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    const int RIGHT = 0, LEFT = 1;
    public float speed;
    private SpriteRenderer Player_Sprite;
    private Rigidbody2D rb;
    public float timechange;
    private float timeleft;
    private float timestopanim;
    private float animduration = 0.6f;
    private float moveVelocity;
    private Animator anim;
    public static int LastKey = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player_Sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timestopanim < 0)
        {
            anim.SetFloat("Attack", 0.0f);
            timestopanim = animduration;
        }
    }

    void FixedUpdate()
    {
        moveVelocity = 0f;

        if (Input.GetKey("d"))
        {
            //rb.velocity = new Vector2(5 * speed, rb.velocity.y);
            moveVelocity = speed * 5;
            LastKey = 0;
            Player_Sprite.flipX = false;
        }
        if (Input.GetKey("a"))
        {
            //rb.velocity = new Vector2(-5 * speed, rb.velocity.y);
            moveVelocity = speed * -5;
            LastKey = 1;
            Player_Sprite.flipX = true;
        }
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        if (Input.GetKeyDown("w") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3 * speed);
        }
        anim.SetFloat("Move", Input.GetAxisRaw("Horizontal"));
    }
}
