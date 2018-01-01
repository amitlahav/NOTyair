using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour 
{
    public float speed;
    private Rigidbody2D rb;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
    {
		if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(5 * speed, rb.velocity.y);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-5 * speed, rb.velocity.y);
        }
        if (Input.GetKeyUp("d"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyUp("a"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown("w") && rb.velocity.y ==  0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3 * speed);
        }
	}
}
