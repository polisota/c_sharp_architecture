using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public IMoveModelView modelViewInterface;
    public MoveView moveView;
    [SerializeField] float speed;
    [SerializeField] Transform platform;

    public IMoveBallModelView modelBallViewInterface;
    public MoveBallView moveBallView;
    [SerializeField] float force;
    [SerializeField] Transform ball;

    private Vector3 startPosBall;
    private Vector3 startPosPl;

    private bool shoot;

    private void Awake()
    {
        Block.blocks = new List<GameObject>();
    }

    void Start()
    {
        shoot = true;
        startPosBall = ball.position;
        startPosPl = platform.position;

        MoveModel moveModel = new MoveModel(speed);
        modelViewInterface = new MoveModelView(moveModel, platform);

        MoveBallModel moveBallModel = new MoveBallModel(force);
        modelBallViewInterface = new MoveBallModelView(moveBallModel, ball.GetComponent<Rigidbody2D>(), ball);

        (modelBallViewInterface as MoveBallModelView).ballTransform.parent = (modelViewInterface as MoveModelView).transformObj;
    }
    
    void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            modelViewInterface.Move(direction, Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0) && shoot == true)
        {
            modelBallViewInterface.MoveBall();
            (modelBallViewInterface as MoveBallModelView).ballTransform.parent = null;
            shoot = false;
        }
    }

    public void Restart()
    {
        shoot = true;
        ball.position = startPosBall;
        platform.position = startPosPl;

        foreach (GameObject block in Block.blocks)
        {
            block.SetActive(true);
        }

        (modelBallViewInterface as MoveBallModelView).ballTransform.parent = (modelViewInterface as MoveModelView).transformObj;
        (modelBallViewInterface as MoveBallModelView).rigidbody2D.velocity = Vector2.zero;
    }
}
