using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolBulletUfo
{
    private HashSet<UfoBullet> _bullets;
    private int _bulletCapacity;

    public PoolBulletUfo(int _bulletCapacity)
    {
        _bullets = new HashSet<UfoBullet>();
        this._bulletCapacity = _bulletCapacity;
    }

    public UfoBullet GetBullet()
    {
        if (_bullets.Count > 0)
        {
            UfoBullet bullet = _bullets.First();
            _bullets.Remove(bullet);
            return bullet;
        }
        return null;
    }

    public bool AddBullet(UfoBullet bullet)
    {
        if (_bullets.Count < _bulletCapacity)
        {
            _bullets.Add(bullet);
            return true;
        }
        return false;
    }
}
