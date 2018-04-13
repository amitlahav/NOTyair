using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    public int SelectedWeapon = 0;
    public int Ammo;
    public int Magazine;
    public List<Transform> MainWeapon = new List<Transform>();// list of all transforms in weaponheld
    /*<Summary>
     * Code used to switch between the owned weapons
     * of the player of which he picked during his playthrough
     * </Summary>
     * <Logic>
     * Creating a list of all Weapons in the transform
     * Declaring first weapon as the starting weapon
     * Each Weapon picked by player changes its status to owned
     * By predetermined Keycodes player can switch between said owned weapons
     * </Logic>*/

    void Start()
    { 
        foreach (Transform Weapon in transform)
        {
            MainWeapon.Add(Weapon);// adding weapons to list
        }
        MainWeapon[0].GetComponent<WeaponsBehaviour>().WeaponOwned = true;// determaning first weapon as main weapon and declaring him as owned
        SelectWeapon();// selecting first weapon
    }


    void Update()
    {
        //For The UI - Taking the Ammo and Magazine from the current selectedWeapon and displays it
        Ammo = MainWeapon[SelectedWeapon].GetComponent<WeaponsBehaviour>().Ammo;
        Magazine = MainWeapon[SelectedWeapon].GetComponent<WeaponsBehaviour>().Magazine;
        //

        if (!MainWeapon[SelectedWeapon].GetComponent<WeaponsBehaviour>().WeaponOwned)// selected first weapon as held weapon if no weapon is currently selected
        {
            SelectedWeapon = 0;
        }


        if (SelectedWeapon <= MainWeapon.Count - 1)//keeping the list boundry
        {
            if (Input.GetKeyDown("p"))// Looking for the next weapon in the list MainWeapon - if found equliazing SelectedWeapon to the location of that next owned weapon 
            {
                int NextWeapon = SelectedWeapon+1;
                for (int i = NextWeapon; i < MainWeapon.Count; i++)
                {
                    if (MainWeapon[i].GetComponent<WeaponsBehaviour>().WeaponOwned)
                    {
                        SelectedWeapon = i;break;
                    }
                }
            }
        }

        if (Input.GetKeyDown("o") && SelectedWeapon > 0)// same but for previous
        {
        int PreviousWeapon = SelectedWeapon - 1;
        for (int i = PreviousWeapon; i >= 0; i--)
         {
            if (MainWeapon[i].GetComponent<WeaponsBehaviour>().WeaponOwned)
            {               
                SelectedWeapon = i; break;
            }
         }
        }
        SelectWeapon();// select weapon
    }


    public void SelectWeapon()// going over all weapons in the the transform and selecting the weapon equals to the int "SelectedWeapon"
    {
        int i = 0;
        foreach(Transform Weapon in transform)
        {   
            if (i == SelectedWeapon && Weapon.GetComponent<WeaponsBehaviour>().WeaponOwned)
            {
                Weapon.gameObject.SetActive(true);
            }
            else
            {
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
