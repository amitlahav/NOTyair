using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMover : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }
    /*void OnCollisionEnter2D(Collision2D Collision)
    {
        Destroy(Collision.otherCollider.gameObject);
        Destroy(Collision.gameObject);
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(rb.gameObject);
    }
}
