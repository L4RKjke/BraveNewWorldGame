public abstract class Enemy : Fighter
{
    abstract public void Atack();

    private void Update()
    {
        if (CurrentTarget != null)
        {
            if (CurrentTarget.transform.position.x > transform.position.x)
                transform.parent.localScale = InvertedScale;
            else
                transform.parent.localScale = DefoaltScale;
        }
    }
}