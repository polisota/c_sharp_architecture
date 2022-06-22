using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private float speed;
    private PoolBullet poolBullet;
    [SerializeField] private int _bulletCapacity;
    [SerializeField] private float hit;

    void Start()
    {
        poolBullet = new PoolBullet(_bulletCapacity);
    }

    public void SpawnBullet(Vector3 bulletPos, Quaternion direction)
    {
        Bullet bullet = poolBullet.GetBullet();

        if (bullet == null)
        {
            BulletFabric.CreateBullet(bulletPos, direction, speed, hit);
        }
        else
        {
            bullet.ActivateBullet(bulletPos, direction);
            bullet.BulletMove();
        }
    }

    public bool ReturnToPool(Bullet bullet)
    {

        return poolBullet.AddBullet(bullet);
    }   
}
