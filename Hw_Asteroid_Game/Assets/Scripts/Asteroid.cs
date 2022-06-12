
using UnityEngine;

public class Asteroid : Enemy
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _asteroidSprite;
    public AsteroidType asteroidType { get; private set; }

    void Awake()
    {
        _rigidbody = GetComponent <Rigidbody2D>();
        _asteroidSprite = GetComponent<SpriteRenderer>();        
    }

    
    void Start()
    {
        if (asteroidType == AsteroidType.ASTL)
            damage = new Damage(70, 70);
        else if (asteroidType == AsteroidType.ASTM)
            damage = new Damage(50, 50);
        else if (asteroidType == AsteroidType.ASTS)
            damage = new Damage(30, 30);
        else if (asteroidType == AsteroidType.ASTXS)
            damage = new Damage(10, 10);
        RandomAsteroidMove();
    }
     

    private void RandomAsteroidMove()
    {
        _rigidbody.AddForce(_rigidbody.transform.up * speed);
    }

    public void OnTriggerEnter2D(Collider bulletCol)
    {
        if(bulletCol.CompareTag("Bullet"))
        {
            poolObject.GetComponent<SpawnController>().ReturnAsteroidToPool(this);
            DeactivateEnemy();
        }
    }

}


public enum AsteroidType
{
    ASTL,
    ASTM,
    ASTS,
    ASTXS
}
