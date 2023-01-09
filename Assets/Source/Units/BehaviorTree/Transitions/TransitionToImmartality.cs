public class TransitionToImmartality : Transition
{
    private Fighter _currentUnit;

    private void Awake()
    {
        _currentUnit = GetComponent<Fighter>();
        _currentUnit.Imortaled += OnImortaled;
    }

    private void OnDisable()
    {
        _currentUnit.Imortaled -= OnImortaled;
    }

    private void OnImortaled()
    {
        NeedTransit = true;
    }
}
