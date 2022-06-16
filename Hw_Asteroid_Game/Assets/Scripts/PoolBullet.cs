using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolBullet 
{
    private HashSet<Bullet> _bullets;
    private int _bulletCapacity;

    public PoolBullet(int _bulletCapacity)
    {
        _bullets = new HashSet<Bullet>();
        this._bulletCapacity = _bulletCapacity;
    }

    public Bullet GetBullet()
    {
        if (_bullets.Count > 0)
        {
            Bullet bullet = _bullets.First();
            _bullets.Remove(bullet);
            return bullet;
        }
        return null;
    }

    public bool AddBullet(Bullet bullet)
    {
        if (_bullets.Count < _bulletCapacity)
        {
            _bullets.Add(bullet);
            return true;
        }
        return false;
    }

}
