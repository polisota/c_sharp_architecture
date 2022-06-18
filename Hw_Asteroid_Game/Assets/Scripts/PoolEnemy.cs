using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolEnemy 
{
    private Dictionary<AsteroidType, HashSet<Asteroid>> asteroidDict;
    private int _astCapacity;

    public PoolEnemy(int _astCapacity)
    {
        asteroidDict = new Dictionary<AsteroidType, HashSet<Asteroid>>();
        this._astCapacity = _astCapacity;
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

    public bool AddAsteroid(Asteroid ast)
    {
        if (asteroidDict.ContainsKey(ast.asteroidType))
        {
            if (asteroidDict[ast.asteroidType].Count < _astCapacity)
            {
                asteroidDict[ast.asteroidType].Add(ast);
                return true;
            }
            return false;           
        }
        else
        {
            HashSet<Asteroid> asteroidHashSet = new HashSet<Asteroid>();
            asteroidHashSet.Add(ast);
            asteroidDict[ast.asteroidType] = asteroidHashSet;
            return true;
        }
    }
}
