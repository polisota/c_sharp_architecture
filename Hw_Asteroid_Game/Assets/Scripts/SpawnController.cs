using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private PoolEnemy _poolEnemy;   

    [SerializeField] private float _xRange;
    [SerializeField] private float _yRange;
    [SerializeField] private float _speedRange;
    [SerializeField] private float _sideOffset;
    
    [SerializeField] private int _astCapacity;
    [SerializeField] private bool _random;

    private Info info;


    void Awake()
    {
        info = LoadInfo.Load();
    }


    void Start()
    {
        _poolEnemy = new PoolEnemy(_astCapacity);
        InvokeRepeating("AsteroidSpawn", 0.5f, 5f);
    }

    public void AsteroidSpawn()
    {
        float xPosition = 0;
        float yPosition = 0;
        Quaternion rotation = Quaternion.identity;
        int sideRandom = (int)Random.Range(1, 5);

        switch (sideRandom)
        {
            case 1:
                xPosition = Random.Range(-_xRange, -_xRange + _sideOffset);
                yPosition = Random.Range(-_yRange, _yRange);
                rotation = Quaternion.Euler(0, 0, Random.Range(-40, -120));
                break;

            case 2:
                xPosition = Random.Range(_xRange - _sideOffset, _xRange);
                yPosition = Random.Range(-_yRange, _yRange);
                rotation = Quaternion.Euler(0, 0, Random.Range(40, 120));
                break;

            case 3:
                yPosition = Random.Range(_yRange - _sideOffset, _yRange);
                xPosition = Random.Range(-_xRange, _xRange);
                rotation = Quaternion.Euler(0, 0, Random.Range(-160, -180));
                break;

            case 4:
                yPosition = Random.Range(-_yRange, -_yRange + _sideOffset);
                xPosition = Random.Range(-_xRange, _xRange);
                rotation = Quaternion.Euler(0, 0, Random.Range(160, 180));
                break;
        }

        int astType = (int)Random.Range(1, 5);        
        AsteroidType asteroidType = AsteroidType.ASTM;
        float speed = 0;
        float health = 0;
        Damage damage = new Damage(0, 0);

        if (astType == 1)
            asteroidType = AsteroidType.ASTL;
        else if (astType == 2)
            asteroidType = AsteroidType.ASTM;
        else if (astType == 3)
            asteroidType = AsteroidType.ASTS;
        else if (astType == 4)
            asteroidType = AsteroidType.ASTXS;

        //damage = new Damage(70, 70);
        if (_random)
        {

            speed = Random.Range(_speedRange, 3 * _speedRange);
            health = Random.Range(50, 80);            
        }
        else
        {
            speed = info.speed[astType - 1];
            health = info.health[astType - 1];            
        }
        damage = new Damage(health, health);


        Asteroid ast = _poolEnemy.GetAsteroid(asteroidType);
        if (ast == null)
        {
            Enemy.CreateAsteroidEnemy(new Vector3(xPosition, 0, yPosition), rotation, asteroidType, speed, damage);
        }
        else
        {
            ast.ActivateEnemy(new Vector3(xPosition, 0, yPosition), rotation);
        }
        
    }

    public bool ReturnAsteroidToPool(Asteroid ast)
    {        
        return _poolEnemy.AddAsteroid(ast);
        
    }
   
}
