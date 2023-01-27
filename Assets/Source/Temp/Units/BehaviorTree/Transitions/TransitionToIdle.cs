using UnityEngine;

public class TransitionToIdle : Transition
{
    private Fighter _currentUnit;

    private void OnEnable()
    {
        _currentUnit = GetComponent<Fighter>();
    }

    private void Update()
    {
        if (_currentUnit.Units.GetLength(_currentUnit.EnemyType) == 0)
        {
            NeedTransit = true;
        }
    }
}
