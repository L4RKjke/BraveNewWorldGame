public class TransitionToStun : Transition
{
    private Fighter _currentUnit;

    private void Awake()
    {
        _currentUnit = GetComponent<Fighter>();
        _currentUnit.Stunned += OnStunned;
    }

    private void OnDisable()
    {
        _currentUnit.Stunned -= OnStunned;
    }

    private void OnStunned()
    {
        NeedTransit = true;
    }
}
