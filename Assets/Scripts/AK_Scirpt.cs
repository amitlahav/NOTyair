using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK_Scirpt : MonoBehaviour {
    private SpriteRenderer AK_Sprite;
	void Start () {
        AK_Sprite = GetComponent<SpriteRenderer>();
	}
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            AK_Sprite.flipX = false;
        }
        if (Input.GetKey("a"))
        {
            AK_Sprite.flipX = true;
        }
        
    }
}
