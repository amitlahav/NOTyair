using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMover : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    private void Start()
    {
        rb.velocity = -transform.right * speed;
    }
}
