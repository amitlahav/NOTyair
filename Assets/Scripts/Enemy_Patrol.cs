﻿using System.Collections;
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
    private void Start()
    {
        EnemySprite = GetComponent<SpriteRenderer>();
        Enemy_body = GetComponent<Rigidbody2D>();
        Random_Movement_Time = Random.Range(3, 5);
        Random_Movement_Length = Random.Range(5, 8);
        CurrentPosition = Enemy_body.position.x;
        NextMove = Random_Movement_Time;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (GetComponent<Health_System_Enemies>().Health >= 0)
        {
            if (TurningLeft)
            {
                if (Enemy_body.position.x >= CurrentPosition + Random_Movement_Length)
                {
                    anim.SetInteger("ChangeState", 0);
                    Idle();
                }
                else
                {
                    EnemyMovementRight();
                    anim.SetInteger("ChangeState", 1);
                }
            }
            else if (!TurningLeft)
            {

                if (Enemy_body.position.x <= CurrentPosition - Random_Movement_Length)
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
    void EnemyMovementRight()
    {
        EnemySprite.flipX = true;
        Enemy_body.velocity = new Vector2(5 * speed, Enemy_body.velocity.y);
    }
    void EnemyMovementLeft()
    {
        EnemySprite.flipX = false;
        Enemy_body.velocity = new Vector2(-5 * speed, Enemy_body.velocity.y);       
    }
    void Idle()
    {
        
        if(NextMove-Time.time >= 0f)
        {
            Enemy_body.velocity = new Vector2(0, 0);
        }
        else
        {
            
            TurningLeft = !TurningLeft;
            NextMove = Time.time + Random_Movement_Time;
            CurrentPosition = Enemy_body.position.x;
        }
    }
}
