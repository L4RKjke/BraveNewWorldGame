using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    private Fighter _unit;

    public Fighter Fighter => _unit;

    private void Awake()
    {
        if (TryGetComponent(out Fighter fighter))
            _unit = fighter;
    }

    protected abstract void ActivateAbility();
}
