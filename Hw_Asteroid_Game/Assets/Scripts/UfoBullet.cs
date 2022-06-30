using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBullet : BulletFabric
{
    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        BulletMove();
        poolObject = GameObject.Find("UfoBulletSpawner").transform;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall") || col.CompareTag("Player"))
        {
            DeactivateBulletUfo();
        }
    }

    public void BulletMove()
    {
        _rigidbody2D.AddForce(Vector3.down * speed);
    }
}
