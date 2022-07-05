using UnityEngine;

public class MoveModelView : IMoveModelView
{
    public IMove moveInterface { get; set; }
    public Transform transformObj;

    public MoveModelView (IMove moveInterface, Transform transformObj)
    {
        this.moveInterface = moveInterface;
        this.transformObj = transformObj;
    }

    public void Move(float dir, float deltaTime)
    {
        transformObj.position = new Vector2(transformObj.position.x + moveInterface.speed * deltaTime * dir, transformObj.position.y);

    }
}
