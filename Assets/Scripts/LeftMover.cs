using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMover : MonoBehaviour {
    /*/<Summary>
     * Sending the Bolt Left
     * Destroying when hitting stuff
     * </Summary
     * <Logic>
     * gives an object velocity to set him going left
     * when touching a collider destroy this gameObject
     * </Logic>/*/

    private Rigidbody2D rb;
    public float speed;
    public int Damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(rb.gameObject);
    }
}
