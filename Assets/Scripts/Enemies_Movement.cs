using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Movement : MonoBehaviour {

    float Random_Movement_Time;
    float Random_Movement_Length;
    private SpriteRenderer EnemySprite;
    bool Left = true;
    Rigidbody2D Enemy_body;
    public float speed;
    float idle_time;
    float CurrentPosition;
    float NextMove;
    private void Start()
    {
        EnemySprite = GetComponent<SpriteRenderer>();
        Enemy_body = GetComponent<Rigidbody2D>();
        Random_Movement_Time = Random.Range(4, 8);
        Random_Movement_Length = Random.Range(5, 8);
        Debug.Log(Random_Movement_Length);
        Debug.Log(Random_Movement_Time);
        CurrentPosition = Enemy_body.position.x;
        NextMove = Random_Movement_Time;
    }
    void Update()
    {
        if (Time.time > NextMove)
        {
            NextMove = Time.time + Random_Movement_Time;
            if (Left)
            {
                EnemyMovementRight();
                Left = false;
            }
            else
            {
                EnemyMovementLeft();
                Left = true;
            }
        }
        Idle();
    }
    void EnemyMovementLeft()
    {
        EnemySprite.flipX = true;
        Debug.Log(Enemy_body.position.x < (Random_Movement_Length + CurrentPosition));
        if (Enemy_body.position.x < (Random_Movement_Length+CurrentPosition))
        {
             Enemy_body.velocity = new Vector2(5 * speed, Enemy_body.velocity.y);
        }
        else
        {
            Idle();
        }
    }
    void EnemyMovementRight()
    {
        EnemySprite.flipX = false;
        Debug.Log(Enemy_body.position.x < (Random_Movement_Length + CurrentPosition));
        if (Enemy_body.position.x > (Random_Movement_Length+CurrentPosition))
        {
            Enemy_body.velocity = new Vector2(-5 * speed, Enemy_body.velocity.y);
        }
        else
        {
            Idle();
        }
    }
    void Idle()
    {
        Enemy_body.velocity = new Vector2(0, 0);
    }
}
