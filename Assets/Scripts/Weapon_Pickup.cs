using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pickup : MonoBehaviour {
    /*/<Summary>
     * if the player presses z when on a Weapon - pick up the weapon and store it
     * </Summary>
     * <Logic>
     * When on a BoxCollider2D trigger if pressed z - searching for the weapon storage in the player transform -> searching there for the weapon
     * declaring it as owned
     * </Logic>/*/

    public int Weapon_Index;
    Transform WeaponHeld;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("z") && other.gameObject.tag == "Player")
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
                    Weapon.GetComponent<WeaponsBehaviour>().WeaponOwned = true; break;// declaring the weapon as owned
                }
            }
        }  
    }
}

