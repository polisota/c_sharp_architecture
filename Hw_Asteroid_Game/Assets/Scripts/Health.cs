
public class Health
{
    public float currrentHp { get; protected set; }
    public float maxHp { get; }

    public Health (float currrentHp, float maxHp)
    {
        this.currrentHp = currrentHp;
        this.maxHp = maxHp;
    }

}
