using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFabric : MonoBehaviour
{
    private Transform poolObject;

    public static Bullet CreateBullet(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        var bullet = new GameObject().SetName("Bullet").AddRigidbody2D().AddSprite(Resources.Load<Sprite>("playerBullet")).BoxCollider2D().AddBulletScript();
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
        //poolObject.GetComponent<

    }
}
