public class TransitionToWalk : DistanceTransition
{
    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget > CurrentFighter.WalkDistance)
            {
                NeedTransit = true;
            }
    }
}
