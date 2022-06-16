using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private float speed;
    private PoolBullet poolBullet;
    [SerializeField] private int _bulletCapacity;

    void Start()
    {
        poolBullet = new PoolBullet(_bulletCapacity);
    }

    public void SpawnBullet(Vector3 bulletPos, Quaternion direction)
    {
        Bullet bullet = poolBullet.GetBullet();

        if (bullet == null)
        {
            BulletFabric.CreateBullet(bulletPos, direction, speed);
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
