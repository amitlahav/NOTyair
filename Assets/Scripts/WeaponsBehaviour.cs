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
    public static int Damage;
    private SpriteRenderer WeaponSprite;
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
                Instantiate(original: Rightshot, position: Rightshotspawn.position, rotation: Rightshotspawn.rotation);
            }
            if (Player_Movement.LastKey == LEFT)
                Instantiate(original: LeftShot, position: Leftshotspawn.position, rotation: Leftshotspawn.rotation);
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
