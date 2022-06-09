
using UnityEngine;

public class Damage : Health
{
    public Damage (float currrentHp, float maxHp) : base(currrentHp, maxHp)
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
