using UnityEngine;

public class TransitionToCelebrate : Transition
{
    private Fighter _currentUnit;

    private void OnEnable()
    {
        _currentUnit = GetComponent<Fighter>();
    }

    private void LateUpdate()
    {
        if ((int)_currentUnit.Units.GetLength(_currentUnit.EnemyType) == 0)
        {
            NeedTransit = true;
        }
    }
}
