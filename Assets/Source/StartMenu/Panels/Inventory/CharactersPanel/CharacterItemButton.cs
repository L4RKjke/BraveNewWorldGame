using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemButton : MonoBehaviour
{
    private InventoryUI _inventoryUI;
    private CharactersItemUI _charactersItemUI;

    private void OnMouseEnter()
    {
        if (_charactersItemUI.GetId(this.gameObject) != 0)
            _inventoryUI.ItemDescriptionUI.UpdateDescription(_inventoryUI.PlayerItemStorage.GetItem(_charactersItemUI.GetId(this.gameObject)));

    }

    private void OnMouseExit()
    {
        if (_charactersItemUI.GetId(this.gameObject) != 0)
            _inventoryUI.ItemDescriptionUI.UpdateDescription(_inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItem.Id));
    }

    public void Init(InventoryUI inventoryUI, CharactersItemUI charactersItemUI)
    {
        _inventoryUI = inventoryUI;
        _charactersItemUI = charactersItemUI;
    }
}
