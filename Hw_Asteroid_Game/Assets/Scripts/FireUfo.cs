using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUfo : IFire
{
    private BulletSpawnUfo _bulletSpawn;

    public FireUfo(BulletSpawnUfo _bulletSpawn)
    {
        this._bulletSpawn = _bulletSpawn;
    }

    public void Shooting(Vector3 bulletPos, Quaternion direction)
    {
        _bulletSpawn.SpawnBulletUfo(bulletPos, direction);
    }
}
