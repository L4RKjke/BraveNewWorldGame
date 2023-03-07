using UnityEngine;

public class AllCharactersItems : InventoryButton
{
    [SerializeField] private CharactersItemUI _characterItemUI;

    public void SetCurrentItem()
    {
        _characterItemUI.SetCurrentItem();
    }
}
