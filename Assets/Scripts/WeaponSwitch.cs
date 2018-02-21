using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    public int SelectedWeapon = 0;
    int i = 0;
    List<Transform> MainWeapon = new List<Transform>();
    void Start()
    {
        foreach (Transform Weapon in transform)
        {
            MainWeapon.Add(Weapon);
            i++;
        }
        MainWeapon[0].GetComponent<WeaponsBehaviour>().WeaponOwned = true;
        SelectWeapon();
    }
    void Update()
    {
        if (!MainWeapon[SelectedWeapon].GetComponent<WeaponsBehaviour>().WeaponOwned)
        {
            SelectedWeapon = 0;
        }
        if (SelectedWeapon <= MainWeapon.Count - 1)
        {
            if (Input.GetKeyDown("p") && MainWeapon[SelectedWeapon+1].GetComponent<WeaponsBehaviour>().WeaponOwned)
            {
                SelectedWeapon++;
            }
        }
            if (Input.GetKeyDown("o") && SelectedWeapon > 0)
            {
                SelectedWeapon--;
            }

        SelectWeapon();
    }
    void SelectWeapon()
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
