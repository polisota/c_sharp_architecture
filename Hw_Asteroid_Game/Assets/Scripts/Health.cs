public class Health
{
    public float currentHp { get; protected set; }
    public float maxHp { get; }

    public Health (float currentHp, float maxHp)
    {
        this.currentHp = currentHp;
        this.maxHp = maxHp;
    }

    public void ToMaxHp ()
    {
        currentHp = maxHp;
    }
}
