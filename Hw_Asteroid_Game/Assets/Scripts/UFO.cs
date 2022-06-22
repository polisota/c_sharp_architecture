using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _asteroidSprite;    

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _asteroidSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {        
        poolObject = GameObject.Find("UFOPool").transform;       
    }

    void FixedUpdate()
    {

    }
}
