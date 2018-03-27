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
            int DropChance;
            Debug.Log(GetComponent<Health_System_Enemies>().Health);
            if (GetComponent<Health_System_Enemies>().Health == 0)
            {
                DropChance = Random.Range(1, 100);
                if (DropChance > 90)
                {
                ItemDrop(HealthPot);
                }
            }
        }
         void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                anim.Play("attack");
            }
        }
    void ItemDrop(GameObject BonusItem)
        {
            Instantiate(BonusItem, transform.position = new Vector2(rb.position.x, -4.05f), rb.transform.rotation);
        }
    }

