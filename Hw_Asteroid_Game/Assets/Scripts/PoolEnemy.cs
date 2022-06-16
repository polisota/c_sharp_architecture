using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolEnemy 
{
    private Dictionary<AsteroidType, HashSet<Asteroid>> asteroidDict;  

    public PoolEnemy()
    {
        asteroidDict = new Dictionary<AsteroidType, HashSet<Asteroid>>();
    }

    public Asteroid GetAsteroid(AsteroidType asteroidType)
    {       
        if (asteroidDict.ContainsKey(asteroidType))
        {
            HashSet<Asteroid> asteroidHashSet = asteroidDict[asteroidType];
            if(asteroidHashSet.Count > 0)
            {
                Asteroid getAsteroid = asteroidHashSet.First();
                asteroidHashSet.Remove(getAsteroid);
                return getAsteroid;
            }
        }
        return null;
    }

    public void AddAsteroid(Asteroid ast)
    {
        if (asteroidDict.ContainsKey(ast.asteroidType))
        {
            asteroidDict[ast.asteroidType].Add(ast);            
        }
        else
        {
            HashSet<Asteroid> asteroidHashSet = new HashSet<Asteroid>();
            asteroidHashSet.Add(ast);
            asteroidDict[ast.asteroidType] = asteroidHashSet;            
        }
    }
}
