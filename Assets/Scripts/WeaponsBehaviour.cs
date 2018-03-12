using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsBehaviour : MonoBehaviour
{
    const int RIGHT = 0, LEFT = 1;
    private float nextfire;
    private float Reload_Time_Left;
    private float timeleft;
    public float ReloadTime;
    public float FireRate;
    public GameObject LeftShot;
    public Transform Leftshotspawn;
    public GameObject Rightshot;
    public Transform Rightshotspawn;
    public int Damage;
    private SpriteRenderer WeaponSprite;
    public bool WeaponOwned;
    public int Weapon_Index;
    public int Ammo;
    public int MaxMagazine;
    public int Magazine;
    void Start()
    {
        WeaponSprite = GetComponent<SpriteRenderer>();
        Magazine = MaxMagazine;
    }
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (Magazine>0) {
            if (Input.GetKeyDown("l") && Time.time > nextfire)
            {
                Magazine--;
                nextfire = Time.time + FireRate;
                if (Player_Movement.LastKey == RIGHT)
                {
                    GameObject BoltRight = Instantiate(original: Rightshot, position: Rightshotspawn.position, rotation: Rightshotspawn.rotation);
                    BoltRight.GetComponent<Mover>().Damage = Damage;
                }
                if (Player_Movement.LastKey == LEFT)
                {
                    GameObject BoltLeft = Instantiate(original: LeftShot, position: Leftshotspawn.position, rotation: Leftshotspawn.rotation);
                    BoltLeft.GetComponent<LeftMover>().Damage = Damage;
                }
            }
        }
        if (Input.GetKeyDown("r") && Ammo !=0 && Time.time > Reload_Time_Left)
        {
            Reload_Time_Left = Time.time + ReloadTime;
            nextfire = Time.time + ReloadTime;
            Invoke("ReloadWeapon", ReloadTime);                
        }
        if (Magazine == 0 && Ammo != 0 && Time.time > Reload_Time_Left)
        {
            Reload_Time_Left = Time.time + ReloadTime;
            nextfire = Time.time + ReloadTime;
            Invoke("ReloadWeapon", ReloadTime);    
        }
        if (Input.GetKey("a"))
        {
            WeaponSprite.flipX = true;
        }
        if (Input.GetKey("d"))
        {
            WeaponSprite.flipX = false;
        }

    }
    void ReloadWeapon()
    {
        if (Ammo >= MaxMagazine)// Option 1 : Normal when just need to fill magazine to its full from ammo
        {
            Ammo = Ammo - (MaxMagazine - Magazine);
            Magazine = MaxMagazine;
        }
        else //Option 2 : when there's not enough ammo to fill an entire magazine
        {
            if (Magazine + Ammo > MaxMagazine)// Option 2a : When  Magazine isnt on 0 
            {
                Ammo -= MaxMagazine - Magazine; // removing from ammo what is needed to fill magazine to its full capacity
                Magazine = MaxMagazine; // filling the magazine to its full capacity
            }
            else// Option 2b : When Magazine is on 0
            {
                Magazine += Ammo; // filling magazine with whats left
                Ammo = 0; // setting the ammo on 0
            }
        }
    }
}
