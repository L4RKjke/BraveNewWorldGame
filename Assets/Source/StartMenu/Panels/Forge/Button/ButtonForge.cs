using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Button))]
public class ButtonForge : InventoryButton
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _standartSprite;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private FillBarForge _fillBar;

    private string _requireName = null;
    private int _requireLevel = 1;
    private int _itemID = -1;

    public string RequireName => _requireName;
    public int RequireLevel => _requireLevel;
    public int ItemID => _itemID;

    private void OnMouseEnter()
    {
        if (_itemID != -1)
            _inventoryUI.ItemDescriptionUI.UpdateDescription(_inventoryUI.PlayerItemStorage.GetItem(_itemID));

    }

    private void OnMouseExit()
    {
        if (_itemID != -1 && _inventoryUI.CurrentItemInventory != null)
            _inventoryUI.ItemDescriptionUI.UpdateDescription(_inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id));
    }

    public void StartFill(Color color)
    {
        float timeFill = 1.5f;
        _fillBar.StartFill(color, timeFill);
    }

    public void SetRequre(string name, int level)
    {
        _requireName = name;
        _requireLevel = level;
    }

    public void SetItemID(int id = -1)
    {
        _itemID = id;
    }

    public void SetSprite(Sprite sprite, Color color)
    {
        _image.sprite = sprite;
        _image.color = color;
    }

    public void ResetInfo()
    {
        SetRequre(null,1);
        SetSprite(_standartSprite, Color.white);
        SetItemID(-1);
        _fillBar.OffFill();
    }
}
