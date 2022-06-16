using UnityEngine;

public class AccelerationMove : MoveTransform
{
    private float _acceleration;

    public AccelerationMove (Rigidbody2D _rigidbody, float speed, float _acceleration, float maxSpeed) : base( _rigidbody, speed, maxSpeed)
    {
        this._acceleration = _acceleration;
    }

    public void AddAcceleration()
    {   
        if(speed < maxSpeed)
        {
            speed += _acceleration;
        }
        
    }

    public void RemoveAcceleration()
    {
        speed = 0;        
    }
}
