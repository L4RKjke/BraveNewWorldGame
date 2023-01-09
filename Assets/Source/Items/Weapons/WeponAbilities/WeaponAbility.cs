using UnityEngine;

public abstract class WeaponAbility : MonoBehaviour
{
    private Fighter _fighter;

    protected Fighter Fighter => _fighter;

    private void Awake()
    {
        _fighter = transform.parent.GetComponent<Fighter>();
    }

    abstract public void ActivateAbility();
}
