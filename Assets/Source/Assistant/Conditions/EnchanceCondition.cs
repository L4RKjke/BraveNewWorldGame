using UnityEngine;

public class EnchanceCondition : Condition
{
    [SerializeField] private ForgeUI _forgeUI;

    private void OnEnable()
    {
        _forgeUI.NewItemReturned += OnItemReturned;
    }

    private void OnDisable()
    {
        _forgeUI.NewItemReturned -= OnItemReturned;
    }

    private void OnItemReturned()
    {
        NeedTransit = true;
    }
}
