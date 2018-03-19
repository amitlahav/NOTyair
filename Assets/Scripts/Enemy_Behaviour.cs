using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_Behaviour : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject HealthPot;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() 
    {
        Debug.Log("afasfs");
        int DropChance;
        Debug.Log(GetComponent<Health_System_Enemies>().Health);
        if (GetComponent<Health_System_Enemies>().Health == 0)
        {
            Debug.Log("got here");
            DropChance = Random.Range(1, 100);
            if (DropChance >1)
            {
                Instantiate(HealthPot ,rb.transform.position ,rb.transform.rotation );
            }
        }
    }
}
