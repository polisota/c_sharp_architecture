using UnityEngine;

public class RotationTransform : IRotation
{
    private Rigidbody2D _rigidbody;
    private float _speedRotation;

    public RotationTransform(Rigidbody2D _rigidbody, float _speedRotation)
    {
        this._rigidbody = _rigidbody; 
        this._speedRotation = _speedRotation;
    }

    public void Rotation(float direction)
    {
        _rigidbody.AddTorque(direction * _speedRotation);        
    }
}
