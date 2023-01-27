public class Warrior : Fighter
{
    public float _damageBonus = 1.5f;

    public override void Atack(int damage)
    {
        base.Atack((int)(damage * _damageBonus));
    }
}