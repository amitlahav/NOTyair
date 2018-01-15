using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour 
{
    const int RIGHT = 0, LEFT = 1;
    public float speed;
    private Rigidbody2D rb;
    public GameObject Rightshot;
    public Transform Rightshotspawn;
    public GameObject LeftShot;
    public Transform Leftshotspawn;
    public GameObject Spooned;
    public Transform SpoonPoint;
    public float timechange;
    private float timeleft;
    private float nextfire;
    public float FireRate;
    private int LastKey = 0;
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();

	}
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (Input.GetButton("Fire1")&& Time.time > nextfire)
        {
            nextfire = Time.time + FireRate;
            if(LastKey == RIGHT)
            Instantiate(original:Rightshot,position: Rightshotspawn.position,rotation: Rightshotspawn.rotation);
            if (LastKey == LEFT)
            Instantiate(original: LeftShot, position: Leftshotspawn.position, rotation:Leftshotspawn.rotation);
        }
        if (timeleft < 0)
        {
            Instantiate(original: Spooned, position: SpoonPoint.position, rotation: SpoonPoint.rotation);
            timeleft = timechange;
        }
    }
    void FixedUpdate () 
    {
		if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(5 * speed, rb.velocity.y);
            LastKey = 0;
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-5 * speed, rb.velocity.y);
            LastKey = 1;
        }
        if (Input.GetKeyUp("d"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyUp("a"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown("w") && rb.velocity.y ==  0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3 * speed);
        }
	}
}
