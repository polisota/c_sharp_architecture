using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnUfo : MonoBehaviour
{
    [SerializeField] private float speed;
    private PoolBulletUfo poolBullet;
    [SerializeField] private int _bulletCapacity;
    [SerializeField] private float hit;

    void Start()
    {
        poolBullet = new PoolBulletUfo(_bulletCapacity);
    }

    public void SpawnBulletUfo(Vector3 bulletPos, Quaternion direction)
    {
        UfoBullet bullet = poolBullet.GetBullet();

        if (bullet == null)
        {
            BulletFabric.CreateBulletUfo(bulletPos, direction, speed, hit);
        }
        else
        {
            bullet.ActivateBullet(bulletPos, direction);
            bullet.BulletMove();
        }
    }

    public bool ReturnToPool(UfoBullet bullet)
    {

        return poolBullet.AddBullet(bullet);
    }
}
