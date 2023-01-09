public class Enemy : Fighter
{
    public void Atack()
    {
        if (CurrentTarget != null)
            CurrentTarget.TakeDamage(Damage);
    }
}