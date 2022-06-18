using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    //private BoxCollider2D _col;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _acceleration;
    [SerializeField] private float maxHp;
    private IMove _moveInterface;
    private IRotation _rotationInterface;
    private IFire _fireInterface;
    private BulletSpawn _bulletSpawn;
    private Ship _ship;
    private float direction;
    private Damage damage;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //_col = GetComponent<BoxCollider2D>();
    }

    void Start()
    {        
        _bulletSpawn = GameObject.Find("BulletSpawner").GetComponent<BulletSpawn>();
        _fireInterface = new Fire(_bulletSpawn);
        _moveInterface = new AccelerationMove(_rigidbody, _speed, _acceleration, _maxSpeed);
        _rotationInterface = new RotationTransform(_rigidbody, _speedRotation);
        _ship = new Ship(_moveInterface, _rotationInterface, _fireInterface);
        damage = new Damage(maxHp, maxHp);
    }

    void Update()
    {        
        if(Input.GetKey(KeyCode.W))
        {
            _ship.AddAcceleration();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _ship.RemoveAcceleration();
        }

        if (Input.GetMouseButtonDown(0))
        {            
            _ship.Shooting(transform.position, transform.rotation);
        }

        direction = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        _ship.Rotation(direction);
        _ship.Move(Time.deltaTime);
    }
}
