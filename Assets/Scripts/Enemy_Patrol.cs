using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour {

    float Random_Movement_Time;
    float Random_Movement_Length;
    private SpriteRenderer EnemySprite;
    int TurningLeft;
    Rigidbody2D Enemy_body;
    public float speed;
    float CurrentPosition;
    float NextMove;
    Animator anim;
    public Player_Detection Detection;
    private void Start()
    {
        EnemySprite = GetComponent<SpriteRenderer>();
        Enemy_body = GetComponent<Rigidbody2D>();
        Random_Movement_Time = Random.Range(1, 8);
        Random_Movement_Length = Random.Range(5,8);
        TurningLeft = Random.Range(0, 2); // 0 for false,1 for true
        CurrentPosition = Enemy_body.position.x;
        NextMove = Random_Movement_Time;
        anim = GetComponent<Animator>();
        Debug.Log(Random_Movement_Length);
        Debug.Log(Random_Movement_Time);
    }
    void Update()
    {
        if (GetComponent<Health_System_Enemies>().Health >= 0)
        {
            if (TurningLeft == 1)// is the next turn left?
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
            else if (TurningLeft == 0)
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
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy") // if hitting a wall or enemy
        {
            SwitchTurns(); // turn the object to not bug
        }
        else if (collision.gameObject.tag == "Bolt"|| collision.gameObject.tag == "LeftBolt") // if enemy hit chase the player
        {
            transform.localScale += new Vector3(Detection.Enemy_Vision_x * 1.5f, Detection.Enemy_Vision_y * 1.5f, 0f);
            transform.GetComponent<Enemy_Patrol>().enabled = false;
            transform.GetComponent<Enemy_Chase>().enabled = true;
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
            
            SwitchTurns();// time done... starting to move to the other side
            NextMove = Time.time + Random_Movement_Time; // starting to count when the next move will be when starting to move with the random movement time randgon integer
            CurrentPosition = Enemy_body.position.x;// saving current position to be as an anchor 
        }
    }
    void SwitchTurns()
    {
        if (TurningLeft == 1)
        {
            TurningLeft = 0;
        }
        else
        {
            TurningLeft = 1;
        }
    }
}
