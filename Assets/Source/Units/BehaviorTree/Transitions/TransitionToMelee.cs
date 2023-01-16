public class TransitionToMelee : DistanceChecker
{
    private readonly float _meleeDistance = 1.5f;

    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget < _meleeDistance)
            {
                NeedTransit = true;
            }
    }
}