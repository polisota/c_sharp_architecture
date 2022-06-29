using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _asteroidSprite;
    private IMove ufoMove;
    public float moveRangeX;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _asteroidSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        ufoMove = new UFOMove(true, speed, _rigidbody, moveRangeX, transform);
        poolObject = GameObject.Find("UFOPool").transform;       
    }

    void FixedUpdate()
    {
        ufoMove.Move(Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D bulletCol)
    {
        if (bulletCol.gameObject.name.Equals("Bullet"))
        {
            SceneController.scoreCount += 1000;

            if (!damage.TakeDamage(bulletCol.gameObject.GetComponent<Bullet>().hit))
            {
                if (poolObject.GetComponent<UFOSpawn>().ReturnUFOToPool(this))
                {
                    DeactivateEnemy();
                }
                else
                {
                    Destroy(gameObject);
                }

                poolObject.GetComponent<UFOSpawn>().Spawn();
            }
        }
    }

}
