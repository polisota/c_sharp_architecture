public class MoveModel : IMove
{
    public float speed { get; set; }

    public MoveModel (float speed)
    {
        this.speed = speed;
    }
}
