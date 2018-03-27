using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detect : MonoBehaviour
{
    float Enemy_Vision_x;
    float Enemy_Vision_y;
    public GameObject Slime;

    void Start()
    {
        Enemy_Vision_x = transform.localScale.x;
        Enemy_Vision_y = transform.localScale.y;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.localScale += new Vector3(Enemy_Vision_x * 1.5f, Enemy_Vision_y * 1.5f, 0f);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.localScale -= new Vector3(Enemy_Vision_x * 1.5f, Enemy_Vision_y * 1.5f, 0f);
        }
    }
}

