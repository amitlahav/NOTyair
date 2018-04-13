using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Mover : MonoBehaviour {

    // Moving a platform - left - at -10 velocity

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10f, 0f);
    }

}
