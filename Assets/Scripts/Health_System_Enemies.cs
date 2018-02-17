using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemies : MonoBehaviour {
    public Sprite MidHP;
    public Sprite FinalHP;
    public int Health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.tag == "Bolt" && Health == 3)
        {
            Destroy(collision.collider.gameObject);
            Health--;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = MidHP;

        }
        else if (collision.gameObject.tag == "Bolt" && Health == 2)
        {
            Destroy(collision.collider.gameObject);
            Health--;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FinalHP;
        }
        else if (collision.gameObject.tag == "Bolt" && Health == 1)
        {
            Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }*/
        if (collision.gameObject.tag == "Bolt")
        {
            Debug.Log("touch");
            Debug.Log(WeaponsBehaviour.Damage);
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
