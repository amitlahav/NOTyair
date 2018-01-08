using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed; 
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {
        Debug.Log("x");
        Destroy(Collision.otherCollider.gameObject);
        Destroy(Collision.gameObject);
    }
}
