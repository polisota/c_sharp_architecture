using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : IMove, IRotation, IFire
{    
    private IMove _imove;
    private IRotation _irotation;
    private IFire _ifire;
   
    public Ship (IMove _imove, IRotation _irotation, IFire _ifire)
    {
        this._imove = _imove;
        this._irotation = _irotation;
        this._ifire = _ifire;
    }

    public void Move (float deltaTime)
    {
        _imove.Move(deltaTime);
    }

    public void Rotation(float direction)
    {
        _irotation.Rotation(direction);
    }

    public void Shooting(Vector3 bulletPos, Quaternion direction)
    {
        _ifire.Shooting(bulletPos, direction);
    }

    public void AddAcceleration()
    {
        if (_imove is AccelerationMove i)
        {
            i.AddAcceleration();
        }        
    }      

    public void RemoveAcceleration()
    {
        if (_imove is AccelerationMove i)
        {
            i.RemoveAcceleration();
        }
    }
}
