using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItemButton : InventoryButton
{
    [SerializeField] private Image _imageItem;
    [SerializeField] private TMP_Text _textItem;
    [SerializeField] private ItemRarityShow _itemRarityShow;

    public ItemRarityShow ItemRarityShow => _itemRarityShow;
    private InventoryUI _inventoryUI;
    private CharactersItemUI _charactersItemUI;

    private void OnMouseEnter()
    {
        if (_charactersItemUI.GetId(this.gameObject) != 0)
            _inventoryUI.ItemDescriptionUI.UpdateDescription(_inventoryUI.PlayerItemStorage.GetItem(_charactersItemUI.GetId(this.gameObject)));

    }

    private void OnMouseExit()
    {
        if (_charactersItemUI.GetId(this.gameObject) != 0 && _inventoryUI.CurrentItemInventory != null)
            _inventoryUI.ItemDescriptionUI.UpdateDescription(_inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id));
    }

    public void SetInformation(Sprite sprite, string text)
    {
        _imageItem.sprite = sprite;
        _textItem.text = text;
    }

    public void Init(InventoryUI inventoryUI, CharactersItemUI charactersItemUI)
    {
        _inventoryUI = inventoryUI;
        _charactersItemUI = charactersItemUI;
    }
}
