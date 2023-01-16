public class TransitionToWalk : DistanceChecker
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget >= AtackDistance)
            {
                NeedTransit = true;
            }
    }
}
