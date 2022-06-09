using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour//, IEnemyFactory
{
    protected Damage damage;
   
    protected float speed;

    /*
     void Start()
    {
        //damage = new Damage(maxHp, maxHp);
    }
    
     */

    public static Asteroid CreateAsteroidEnemy(Vector3 enemyPosition, Quaternion enemyRotation, AsteroidType asteroidType, float speed)
    {
        Asteroid asteroid = null;

        switch(asteroidType)        
        {
            case AsteroidType.ASTL :
                asteroid = Instantiate(Resources.Load<Asteroid>("AsteroidL"), enemyPosition, enemyRotation);                
                break;

            case AsteroidType.ASTM:
                asteroid = Instantiate(Resources.Load<Asteroid>("AsteroidM"), enemyPosition, enemyRotation);               
                break;

            case AsteroidType.ASTS:
                asteroid = Instantiate(Resources.Load<Asteroid>("AsteroidS"), enemyPosition, enemyRotation);                
                break;

            case AsteroidType.ASTXS:
                asteroid = Instantiate(Resources.Load<Asteroid>("AsteroidXS"), enemyPosition, enemyRotation);              
                break;
        }
        //asteroid.damage = enemyDamage;
        asteroid.speed = speed;
        return asteroid;
    }


}

