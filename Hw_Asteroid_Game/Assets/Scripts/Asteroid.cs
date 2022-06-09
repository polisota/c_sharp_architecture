
using UnityEngine;

public class Asteroid : Enemy
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _asteroidSprite;

    void Awake()
    {
        _rigidbody = GetComponent <Rigidbody2D>();
        _asteroidSprite = GetComponent<SpriteRenderer>();
    }
}
