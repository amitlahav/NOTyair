using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
    {
    /*<Summary>
     * Controlling several function of the "Enemy"
     * #Drop system - dropping potions
     * #Animation - Attack animation
     * </Summary>
     * <Logic>
     * #When player is at collision with "Enemy" set the animator trigger "Attack"
     * #Setting a random integer to be the drop chance of the item
     * #Dropped when the Enemy's health is 0
     * #Setting a bolean of - if tried to drop and failed or succeded - 
     * to avoid the fact that the Enemy dies in few frames and not just once
     * and by doing so making the drop system work only once as supposed to do
     * </Logic>*/
    public GameObject HealthPot;
    Animator anim;
    bool TryDroppedPotion = false;
    void Start()
        {
            anim = GetComponent<Animator>();
        }
        void Update()
        {
        ItemDrop();
        }
         void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            anim.SetTrigger("Attack");
            }
        }

    void ItemDrop()
    {
        if (GetComponent<Health_System_Enemies>().Health <= 0)
        {
            int DropChance;
            DropChance = Random.Range(1, 100);
            if (DropChance > 80&&TryDroppedPotion == false)
            {
                UIManager.Potions++;
            }
            TryDroppedPotion = true;
        }
    }
}


