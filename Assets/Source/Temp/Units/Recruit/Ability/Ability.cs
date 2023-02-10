using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent (typeof(Fighter))]

public abstract class Ability : MonoBehaviour
{
    protected Fighter Fighter => GetComponent<Fighter>();

    protected Health Health => GetComponent<Health>();    

    protected abstract void ActivateAbility();
}
