using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolUFO
{
    private HashSet<UFO> _ufos;
    private int _ufoCapacity;

    public PoolUFO(int _ufoCapacity)
    {
        _ufos = new HashSet<UFO>();
        this._ufoCapacity = _ufoCapacity;
    }

    public UFO GetUFO()
    {
        if (_ufos.Count > 0)
        {
            UFO ufo = _ufos.First();
            _ufos.Remove(ufo);
            return ufo;
        }
        return null;
    }

    public bool AddUFO(UFO ufo)
    {
        if (_ufos.Count < _ufoCapacity)
        {
            _ufos.Add(ufo);
            return true;
        }
        return false;
    }
}
