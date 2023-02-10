public class Warrior : Recruit
{
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

    private int GetAdvancedDamage() => (Damage + MagicPower);
}