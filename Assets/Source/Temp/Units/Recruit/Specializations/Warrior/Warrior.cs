using UnityEngine;

public class Warrior : Recruit
{
    private readonly int _magicPowerFactor = 20;

    public override void Atack(int damage)
    {
        ChooseAtack(OnDefaultAtack, OnAdvancedAtack);
    }

    protected override void OnDefaultAtack()
    {
        base.Atack(Damage);
    }

    override protected void OnAdvancedAtack()
    {
        base.Atack(GetAdvancedDamage());
    }

    private int GetAdvancedDamage() => (Damage * MagicPower / _magicPowerFactor);
}