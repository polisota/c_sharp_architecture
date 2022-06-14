using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolEnemy 
{
    private Dictionary<AsteroidType, HashSet<Asteroid>> asteroidDict;
    //private int size;
    //private int _countL;
    //private int _countM;
    //private int _countS;
    //private int _countXS;

    public PoolEnemy()//int _countL, int _countM, int _countS, int _countXS)
    {
        //this._countL = _countL;
        //this._countM = _countM;
        //this._countS = _countS;
        //this._countXS = _countXS;
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
