using UnityEngine;

public class Damage : Health
{
    public Damage (float currentHp, float maxHp) : base(currentHp, maxHp)
    {

    }

    public bool TakeDamage(float hit)
    {
        currentHp -= hit;

        if(currentHp <= 0)
        {
            return false;
        }

        return true;
    }
}
