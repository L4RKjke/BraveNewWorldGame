using UnityEngine;

public abstract class WeaponAbility : MonoBehaviour
{
    private Fighter _fighter;

    protected Fighter Fighter => _fighter;

    private void Awake()
    {
        if (transform.parent.TryGetComponent(out Fighter fighter)) ;
            _fighter = fighter;
    }

    abstract public void ActivateAbility();
}
