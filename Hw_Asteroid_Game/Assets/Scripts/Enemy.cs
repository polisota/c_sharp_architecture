using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Damage damage;   
    protected float speed;
    protected Transform poolObject;    
   
    public static UFO CreateUFO(Vector3 enemyPosition, Quaternion enemyRotation, float speed, Damage enemyDamage, float moveRangeX, float shootSkip)
    {
        UFO ufo = Instantiate(Resources.Load<UFO>("ufo"), enemyPosition, enemyRotation);
        ufo.damage = enemyDamage;
        ufo.speed = speed;
        ufo.moveRangeX = moveRangeX;
        ufo.shootSkip = shootSkip;
        return ufo;
    }

    public static Asteroid CreateAsteroidEnemy(Vector3 enemyPosition, Quaternion enemyRotation, AsteroidType asteroidType, float speed, Damage enemyDamage)
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
        asteroid.damage = enemyDamage;
        asteroid.speed = speed;
        return asteroid;
    }

    public virtual void ActivateEnemy(Vector3 enemyPosition, Quaternion enemyRotation)
    {
        transform.position = enemyPosition;
        transform.rotation = enemyRotation;
        gameObject.SetActive(true);
        damage.ToMaxHp();
    }

    protected virtual void DeactivateEnemy()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.parent = poolObject;
        //poolObject.GetComponent<
    }
}

