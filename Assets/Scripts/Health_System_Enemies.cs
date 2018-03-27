using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System_Enemies : MonoBehaviour {
    public int Health;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();  
    }
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
            anim.Play("hurt");
            yield return new WaitForSeconds(0.4f);
        }
        if (collision.gameObject.tag == "LeftBolt")
        {
            Health -= collision.gameObject.GetComponent<LeftMover>().Damage;
            anim.Play("hurt");
            yield return new WaitForSeconds(0.4f);
        }
        if (Health <= 0)
        {
            yield return null;
            anim.Play("die");
            yield return new WaitForSecondsRealtime(0.4f);
            Health = 0;
            Destroy(this.gameObject);
            UIManager.Score += 50;
        }
    }
}
