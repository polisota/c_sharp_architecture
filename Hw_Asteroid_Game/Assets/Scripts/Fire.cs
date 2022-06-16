using UnityEngine;

public class Fire : IFire
{
    private BulletSpawn _bulletSpawn;    

    public Fire(BulletSpawn _bulletSpawn)
    {
        this._bulletSpawn = _bulletSpawn;
    }

    public void Shooting(Vector3 bulletPos, Quaternion direction)
    {
        _bulletSpawn.SpawnBullet(bulletPos, direction);
    }
}
