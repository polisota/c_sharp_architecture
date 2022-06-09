using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private float _xRange;
    [SerializeField] private float _yRange;
    [SerializeField] private float _sideOffset;

    void Start()
    {
        AsteroidSpawn();
    }

    public void AsteroidSpawn()
    {
        float xPosition = 0;
        float yPosition = 0;
        Quaternion rotation = Quaternion.identity;
        int sideRandom = (int)Random.Range(1, 5);

        switch(sideRandom)
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
        //float astType = System.Random.Next(1, 5);
        AsteroidType asteroidType = AsteroidType.ASTM;
        if (astType == 1)
            asteroidType = AsteroidType.ASTL;        
        else if (astType == 2)
            asteroidType = AsteroidType.ASTM;
        else if (astType == 3)
            asteroidType = AsteroidType.ASTS;
        else if (astType == 4)
            asteroidType = AsteroidType.ASTXS;

        float speed = Random.Range(100, 500);

        Enemy.CreateAsteroidEnemy(new Vector3 (xPosition, 0, yPosition), rotation, asteroidType, speed);
    }
}
