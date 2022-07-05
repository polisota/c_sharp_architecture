using UnityEngine;

public class MoveBallModelView : IMoveBallModelView
{
    public IMoveBall moveBallInterface { get; set; }
    public Rigidbody2D rigidbody2D;
    public Transform ballTransform;

    public MoveBallModelView(IMoveBall moveBallInterface, Rigidbody2D rigidbody2D, Transform ballTransform)
    {
        this.moveBallInterface = moveBallInterface;
        this.rigidbody2D = rigidbody2D;
        this.ballTransform = ballTransform;
    }

    public void MoveBall()
    {
        rigidbody2D.AddForce(rigidbody2D.transform.up * moveBallInterface.force);
    }
}
