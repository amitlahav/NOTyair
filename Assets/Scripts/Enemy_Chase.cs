using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chase : MonoBehaviour 
{
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void Update()// moving towoard player
    {
        if (GameObject.FindWithTag("Player").transform.position.x < rb.position.x)
        {
            rb.velocity = new Vector2(-5 * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(5 * speed, rb.velocity.y);
        }
    }
}
