using UnityEngine;

public class HealEffect : Effect
{
    [SerializeField] private Priest _unit;

    private void OnEnable()
    {
        _unit.HealStarted += Play;
    }

    private void OnDisable()
    {
        _unit.HealStarted -= Play;
    }

    private void FixedUpdate()
    {
        if (_unit.Mate != null)
            Move(_unit.Mate);
    }
}