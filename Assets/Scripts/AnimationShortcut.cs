using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShortcut : MonoBehaviour {
    private SpriteRenderer Staff;
	void Start () {
        Staff = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey("d"))
        {
            Staff.flipX = false;
        }
        if (Input.GetKey("a"))
        {
           Staff.flipX = true;
        }
    }
}
