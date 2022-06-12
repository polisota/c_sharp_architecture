using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : IFire
{
    Vector3 bulletPos;
    //Vector3 direction;

    public Fire(Vector3 bulletPos)
    {
        this.bulletPos = bulletPos;
    }

    void Shooting(Vector3 bulletPos, Vector3 direction)
    {

    }
}
