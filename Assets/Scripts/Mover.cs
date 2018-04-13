using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    /*/<Summary>
 * Sending the Bolt Right
 * Destroying when hitting stuff
 * </Summary
 * <Logic>
 * gives an object velocity to set him going Right
 * when touching a collider destroy this gameObject
 * </Logic>/*/

    private Rigidbody2D rb;
    public float speed;
    public int Damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(rb.gameObject);
    }
}
