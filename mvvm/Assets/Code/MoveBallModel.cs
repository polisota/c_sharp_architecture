public class MoveBallModel : IMoveBall
{
    public float force { get; set; }

    public MoveBallModel(float force)
    {
        this.force = force;
    }
}
