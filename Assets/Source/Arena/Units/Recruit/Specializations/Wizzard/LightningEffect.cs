using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class LightningEffect : Effect
{
    [SerializeField] private Wizzard _unit;

    private void OnEnable()
    {
        _unit.LightningUsed += Play;
    }

    private void OnDisable()
    {
        _unit.LightningUsed -= Play;
    }

    private void FixedUpdate()
    {
        if (_unit.CurrentTarget != null)
            Move(_unit.CurrentTarget);
    }
}