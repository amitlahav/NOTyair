using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
    {
        Rigidbody2D rb;
        public GameObject HealthPot;
        Animator anim;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        void Update()
        {
        StartCoroutine(ItemDrop());   
        }
         void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            anim.SetTrigger("Attack");
            }
        }
    void ItemDrop(GameObject BonusItem)
    {
        BonusItem.transform.position = new Vector2(transform.position.x, -4.05f);
        Instantiate(BonusItem, BonusItem.transform.position, rb.transform.rotation);
    }
    IEnumerator ItemDrop()
    {
        Debug.Log(GetComponent<Health_System_Enemies>().Health);
        if (GetComponent<Health_System_Enemies>().Health <= 0)
        {
            int DropChance;
            DropChance = Random.Range(1, 100);
            if (DropChance > 99)
            {
                ItemDrop(HealthPot);
                yield return null;
            }
        }
    }
}


