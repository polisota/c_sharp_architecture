using UnityEngine;

public class MoveTransform : IMove
{
    private Rigidbody2D _rigidbody;
    public float speed { get; protected set; }
    public float maxSpeed { get; }
    private Vector3 _move;

    public MoveTransform(Rigidbody2D _rigidbody, float speed, float maxSpeed)
    {
        this._rigidbody = _rigidbody;
        this.speed = speed;
        this.maxSpeed = maxSpeed;
}

    public void Move( float deltaTime)
    {
        float _speed = deltaTime * speed;
        //_move = _rigidbody.transform.position + new Vector3(0, speed, 0);
        //_rigidbody.MovePosition(_move);
        _rigidbody.AddForce(_speed * _rigidbody.transform.up);
    }

}
