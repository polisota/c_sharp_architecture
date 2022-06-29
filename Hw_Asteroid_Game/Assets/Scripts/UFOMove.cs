using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : IMove
{
    private Rigidbody2D _rigidbody;
    private bool moveRight;
    private float speed;
    private float moveRangeX;
    private Transform transformUfo;

    public UFOMove (bool moveRight, float speed, Rigidbody2D _rigidbody, float moveRangeX, Transform transformUfo)
    {
        this.moveRangeX = moveRangeX;
        this._rigidbody = _rigidbody;
        this.moveRight = moveRight;
        this.speed = speed;
        this.transformUfo = transformUfo;
    }

    public void Move(float deltaTime)
    {
        CheckPosition();
        if (moveRight)
        {
            _rigidbody.MovePosition(new Vector3 (transformUfo.position.x + speed * deltaTime, transformUfo.position.y, 0));
            //transform.position = new Vector2(transform.position.x + speed * deltaTime, transform.position.y);
        }
        else
        {
            _rigidbody.MovePosition(new Vector3 (transformUfo.position.x - speed * deltaTime, transformUfo.position.y, 0));
            //transform.position = new Vector2(-transform.position.x + speed * deltaTime, -transform.position.y);
        }
    }

    void CheckPosition()
    {
        if (!moveRight && transformUfo.position.x <= -moveRangeX)
        {
            moveRight = true;            
        }
        else if (moveRight && transformUfo.position.x >= moveRangeX)
        {
            moveRight = false;
        }        
    }
}
