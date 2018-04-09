using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
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
        //Fist_Right = transform.Find("Fist_Right");
        //Fist_Left = transform.Find("Fist_Left");
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
          //  Fist_Right.gameObject.SetActive(true);
          //  Fist_Left.gameObject.SetActive(false);
            Player_Sprite.flipX = false;
        }
        if (Input.GetKey("a"))
        {
            moveVelocity = speed * -5;
            LastKey = 1;
           // Fist_Right.gameObject.SetActive(false);
           // Fist_Left.gameObject.SetActive(true);
            Player_Sprite.flipX = true;
        }
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        anim.SetFloat("Move", Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown("w") && rb.velocity.y == 0)
        {   
            rb.velocity = new Vector2(rb.velocity.x, 3 * speed);
        }
    }
}
