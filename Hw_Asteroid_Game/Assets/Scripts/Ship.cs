using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : IMove, IRotation
{
    
    private IMove _imove;
    private IRotation _irotation;
   
    public Ship (IMove _imove, IRotation _irotation)
    {
        this._imove = _imove;
        this._irotation = _irotation;
    }

    public void Move (float deltaTime)
    {
        _imove.Move(deltaTime);
    }

    public void Rotation(float direction)
    {
        _irotation.Rotation(direction);
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
