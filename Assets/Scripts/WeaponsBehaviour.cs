using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsBehaviour : MonoBehaviour
{
    const int RIGHT = 0, LEFT = 1;
    private float nextfire;
    private float timeleft;
    public float FireRate;
    public GameObject LeftShot;
    public Transform Leftshotspawn;
    public GameObject Rightshot;
    public Transform Rightshotspawn;
    public int Damage;
    private SpriteRenderer WeaponSprite;
    public bool WeaponOwned;
    public int Weapon_Index;
    void Start()
    {
        WeaponSprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (Input.GetKeyDown("l") && Time.time > nextfire)
        {
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
        if (Input.GetKey("a"))
        {
            WeaponSprite.flipX = true;
        }
        if (Input.GetKey("d"))
        {
            WeaponSprite.flipX = false;
        }
    }
}
