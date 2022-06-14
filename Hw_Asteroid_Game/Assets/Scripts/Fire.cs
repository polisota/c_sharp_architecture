using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : IFire
{
    private Vector3 bulletPos;
    //Vector3 direction;
    private PoolBullet poolBullet;

    public Fire(Vector3 bulletPos, PoolBullet poolBullet)
    {
        this.bulletPos = bulletPos;
        this.poolBullet = poolBullet;
    }

    public void Shooting(Vector3 bulletPos, Vector3 direction)
    {
       if(poolBullet.GetBullet() == null)
       {
            BulletFabric.CreateBullet(bulletPos, direction);
       }
    }
}
