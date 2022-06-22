using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : IMove
{
    private bool moveRight;
    private float speed;
    private float moveRangeX;

    public UFOMove (bool moveRight, float speed)
    {
        this.moveRight = moveRight;
        this.speed = speed;
    }

    public void Move(float deltaTime)
    {
        CheckPosition();
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(-transform.position.x + speed * deltaTime, -transform.position.y);
        }
    }

    void CheckPosition()
    {
        if (!moveRight && transform.position.x <= -moveRangeX)
        {
            moveRight = true;            
        }
        else if (moveRight && transform.position.x <= moveRangeX)
        {
            moveRight = false;
        }        
    }
}
