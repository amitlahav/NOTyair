using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour {

    float Random_Movement_Time;
    float Random_Movement_Length;
    private SpriteRenderer EnemySprite;
    bool TurningLeft = true;
    Rigidbody2D Enemy_body;
    public float speed;
    float CurrentPosition;
    float NextMove;
    Animator anim;
    RaycastHit2D Wall;
    private void Start()
    {
        EnemySprite = GetComponent<SpriteRenderer>();
        Enemy_body = GetComponent<Rigidbody2D>();
        Random_Movement_Time = Random.Range(4, 5);
        Random_Movement_Length = Random.Range(5,8);
        CurrentPosition = Enemy_body.position.x;
        NextMove = Random_Movement_Time;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (GetComponent<Health_System_Enemies>().Health >= 0)
        {
            if (TurningLeft)// is the next turn left?
            {
                if (Enemy_body.position.x >= CurrentPosition + Random_Movement_Length)// checking the objects location; if its bigger than the inital position
                {
                    anim.SetInteger("ChangeState", 0);
                    Idle();// object reached destination , rests for a random time period
                }
                else
                {
                    EnemyMovementRight();// if didnt reach destination, keeps moving right
                    anim.SetInteger("ChangeState", 1);
                }
            }
            else if (!TurningLeft)
            {

                if (Enemy_body.position.x <= CurrentPosition - Random_Movement_Length)//same as above for the oposite side
                {
                    anim.SetInteger("ChangeState", 0);
                    Idle();
                }
                else
                {
                    EnemyMovementLeft();
                    anim.SetInteger("ChangeState", 1);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") // if hitting a wall
        {
            TurningLeft = !TurningLeft; // turn the object to not bug
        }
    }
    void EnemyMovementRight()
    {
        EnemySprite.flipX = true;
        Enemy_body.velocity = new Vector2(5 * speed, Enemy_body.velocity.y);// gives velocity to the right side
    }
    void EnemyMovementLeft()
    {
        EnemySprite.flipX = false;
        Enemy_body.velocity = new Vector2(-5 * speed, Enemy_body.velocity.y);// gives velocity to the left side
    }
    void Idle()
    {
        
        if(NextMove-Time.time >= 0f)// object reseting velocity until time has come
        {
            Enemy_body.velocity = new Vector2(0, 0);// rest
        }
        else
        {
            
            TurningLeft = !TurningLeft;// time done... starting to move to the other side
            NextMove = Time.time + Random_Movement_Time; // starting to count when the next move will be when starting to move with the random movement time randgon integer
            CurrentPosition = Enemy_body.position.x;// saving current position to be as an anchor 
        }
    }
}
