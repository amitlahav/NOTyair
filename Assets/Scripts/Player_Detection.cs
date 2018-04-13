using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
    /*/<Summary>
     * Switching between the patrol and chase functions of the enemies
     * </Summary>
     * <Logic>
     * when Player entering the BoxCollider2D Trigger of the Enemy - Expand it and start the chase function
     * when leaving return it to normal and switch to patrol
     * </Logic>/*/

    public float Enemy_Vision_x;
    public float Enemy_Vision_y;
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
            Slime.GetComponent<Enemy_Patrol>().enabled = false;
            Slime.GetComponent<Enemy_Chase>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.localScale -= new Vector3(Enemy_Vision_x * 1.5f, Enemy_Vision_y * 1.5f, 0f);
            Slime.GetComponent<Enemy_Patrol>().enabled = true;
            Slime.GetComponent<Enemy_Chase>().enabled = false;
        }
    }
}

