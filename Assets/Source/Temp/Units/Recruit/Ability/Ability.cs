using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected Fighter Fighter => GetComponent<Fighter>();

    protected Health Health => GetComponent<Health>();

    protected abstract void ActivateAbility();

    public abstract void SetAbility(Recruit recruit);
}
