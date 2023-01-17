public class TransitionToAtack : DistanceChecker
{
    private readonly float _atackDistance = 5;

    private void Update()
    {
        if (CurrentFighter.CurrentTarget != null)
            if (DistanceToTarget < _atackDistance)
            {
                NeedTransit = true;
            }
    }
}