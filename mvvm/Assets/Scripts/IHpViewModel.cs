using System;

public interface IHpViewModel
{
    IHpModel HpModel { get; }
    bool IsDead { get; }
    void ApplyDamage(float damage);
    event Action<float> OnHpChange;
}
