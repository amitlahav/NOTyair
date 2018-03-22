using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemies : MonoBehaviour {
    public int Health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(BoltCollision(collision));
    }
    void HealthToRemove(int HealthToRemove)
    {
        Health -= HealthToRemove;
    }
    IEnumerator BoltCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bolt")
        {
            Health -= collision.gameObject.GetComponent<Mover>().Damage;
        }
        if (collision.gameObject.tag == "LeftBolt")
        {
            Health -= collision.gameObject.GetComponent<LeftMover>().Damage;
        }
        if (Health <= 0)
        {
            Health = 0;
            yield return null;
            Destroy(this.gameObject);
            UIManager.Score += 50;
        }
    }
}
