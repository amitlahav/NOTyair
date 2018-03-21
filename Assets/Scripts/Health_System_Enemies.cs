using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemies : MonoBehaviour {
    public int Health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bolt")
        {
            Health -= collision.gameObject.GetComponent<Mover>().Damage;   
        }
        if (collision.gameObject.tag == "LeftBolt")
        {
            Health -= collision.gameObject.GetComponent<LeftMover>().Damage;
        }
        if (Health<=0)
        {
            Destroy(this.gameObject);
        }
    }
    void HealthToRemove(int HealthToRemove)
    {
        Health -= HealthToRemove;
    }

}
