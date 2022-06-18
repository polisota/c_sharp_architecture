using UnityEngine;

public class BulletFabric : MonoBehaviour
{
    protected Transform poolObject;
    protected float speed;    

    public static Bullet CreateBullet(Vector3 bulletPosition, Quaternion bulletRotation, float speed)
    {
        var bullet = new GameObject().SetName("Bullet").AddRigidbody2D(0).AddSprite(Resources.Load<Sprite>("playerBullet")).BoxCollider2D(true).AddBulletScript();
        bullet.transform.rotation = bulletRotation;
        bullet.transform.position = bulletPosition;
        bullet.GetComponent<Bullet>().speed = speed;
        return bullet.GetComponent<Bullet>();
    }


    public void ActivateBullet(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        transform.position = bulletPosition;
        transform.rotation = bulletRotation;
        gameObject.SetActive(true);
    }

    protected void DeactivateBullet()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.parent = poolObject;
        Debug.Log(GetComponent<Bullet>());
        Debug.Log(poolObject);
        if (!poolObject.GetComponent<BulletSpawn>().ReturnToPool(GetComponent <Bullet>()))
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
