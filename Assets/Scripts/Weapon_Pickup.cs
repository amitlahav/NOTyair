using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : MonoBehaviour {
    public int Weapon_Index;
    List<Transform> Weapons = new List<Transform>();
    Transform WeaponHeld;
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("z"))
        {
            Destroy(gameObject);
            foreach (Transform Weapon in other.transform)// finding in the player transform the child "WeaponHeld"
            {
                if (Weapon.tag =="Weapon")
                {
                    WeaponHeld = Weapon;
                }
            }
            foreach (Transform Weapon in WeaponHeld)// going through all the weapons in the transform until finding the one with same index as the weapon being picked up
            {
                if (Weapon.GetComponent<WeaponsBehaviour>().Weapon_Index == Weapon_Index)
                {
                    Weapon.GetComponent<WeaponsBehaviour>().WeaponOwned = true;break;// declaring the weapon as owned
                }
            }
        }  
    }
}

