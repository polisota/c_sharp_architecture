using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletFabric
{
    private Rigidbody2D _rigidbody2D;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody2D.AddForce(transform.up*speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DeactivateBullet();
    }
}
