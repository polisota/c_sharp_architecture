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
        BulletMove();
        poolObject = GameObject.Find("BulletSpawner").transform;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        DeactivateBullet();
    }

    public void BulletMove()
    {
        _rigidbody2D.AddForce(transform.up * speed);
    }
}
