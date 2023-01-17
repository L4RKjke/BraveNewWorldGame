public class CloseAtacker : Enemy
{
    public override void Atack()
    {
        if (CurrentTarget != null)
            CurrentTarget.TakeDamage(Damage);
    }
}
