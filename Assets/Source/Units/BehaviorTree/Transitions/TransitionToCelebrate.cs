using UnityEngine;

public class TransitionToCelebrate : Transition
{
    private Fighter _currentUnit;

    private void OnEnable()
    {
        _currentUnit = GetComponent<Fighter>();
    }

    private void Update()
    {
        Debug.Log(_currentUnit.Units.GetLength(_currentUnit.EnemyType));

        if ((int)_currentUnit.Units.GetLength(_currentUnit.EnemyType) == 0)
        {
            Debug.Log(_currentUnit.Units.GetLength(_currentUnit.EnemyType) + " waht");
            NeedTransit = true;
        }
    }
}
