using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _asteroidSprite;
    private IMove ufoMove;
    public float moveRangeX;
    private IFire _fireInterface;
    private BulletSpawnUfo _bulletSpawn;
    public float shootSkip;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _asteroidSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        ufoMove = new UFOMove(true, speed, _rigidbody, moveRangeX, transform);
        poolObject = GameObject.Find("UFOPool").transform;
        _bulletSpawn = GameObject.Find("UfoBulletSpawner").GetComponent<BulletSpawnUfo>();
        _fireInterface = new FireUfo(_bulletSpawn);

        StartCoroutine (UfoShoot());
    }

    IEnumerator UfoShoot()
    {
        do
        {
            _fireInterface.Shooting(transform.position, Quaternion.identity);
            yield return new WaitForSeconds(shootSkip);
        }
        while (damage.currentHp > 0);
    }

    public override void ActivateEnemy(Vector3 enemyPosition, Quaternion enemyRotation)
    {
        transform.position = enemyPosition;
        transform.rotation = enemyRotation;
        gameObject.SetActive(true);
        damage.ToMaxHp();
        StartCoroutine(UfoShoot());
    }

    protected override void DeactivateEnemy()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.parent = poolObject;
        StopCoroutine(UfoShoot());
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
