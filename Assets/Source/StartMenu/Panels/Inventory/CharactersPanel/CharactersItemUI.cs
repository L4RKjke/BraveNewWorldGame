using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersItemUI : RenderUI
{
    [SerializeField] private List<SlotItems> _equipmentSlot = new List<SlotItems>();
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;

    private void Awake()
    {
        AddGraphics();
    }

    public void SetCurrentItem()
    {
        Debug.Log(_inventoryUI.CurrentItemInventory.Id);

        if (_inventoryUI.CurrentItemInventory.Id != 0)
        {

            Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id);

            for (int i = Container.transform.childCount - 1; i >= 0; i--)
            {
                if (_equipmentSlot[i].ItemType == item.Type || (item.Type == ItemType.Weapon && _equipmentSlot[i].ItemType == ItemType.Hand))
                {
                    if(_equipmentSlot[i].ItemId == 0)
                    {
                        Button button = Container.transform.GetChild(i).GetComponentInChildren<Button>();
                        button.onClick.Invoke();
                        return;
                    }
                }
            }
        }
    }

    public void SetIdSlot(GameObject button, int itemId)
    {
        int id = int.Parse(button.name);
        _equipmentSlot[id].SetId(itemId);
    }    

    public ItemType GetType(GameObject button)
    {
        int id = int.Parse(button.name);

        return _equipmentSlot[id].ItemType;
    }

    public int GetId(GameObject button)
    {
        int id = int.Parse(button.name);

        return _equipmentSlot[id].ItemId;
    }

    public void UpdateAllButtons(GameObject character)
    {
        CharacterItems charactersItems = character.GetComponent<CharacterItems>();

        for (int i = 0; i < _equipmentSlot.Count; i++)
        {
            Item tempItem = charactersItems.GetItem(_equipmentSlot[i].ItemType);

            GameObject button = Container.transform.GetChild(i).gameObject;

            if (tempItem != null)
            {
                UpdateButtonGraphicsEquip(button, tempItem);
            }
            else
            {
                UpdateButtonGraphicsUnequip(button);
            }
        }
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _equipmentSlot.Count; i++)
        {
            GameObject newButton = Instantiate(Content, Container.transform) as GameObject;
            newButton.name = i.ToString();
            newButton.GetComponent<CharacterItemButton>().Init(_inventoryUI, this);

            UpdateButtonGraphicsUnequip(newButton);
        }
    }

    private void UpdateButtonGraphicsEquip(GameObject button, Item item)
    {
        CharacterItemButton characterItemButton = button.GetComponent<CharacterItemButton>();
        characterItemButton.SetInformation(item.Image, item.Name);

        characterItemButton.ItemRarityShow.gameObject.SetActive(true);
        Color color = _inventoryUI.ItemRarity.GetColor(item.Level - 1);
        characterItemButton.ItemRarityShow.SetRarity(color);

        Button tempButton = button.GetComponentInChildren<Button>();
        tempButton.onClick.RemoveAllListeners();
        SetIdSlot(button, item.Id);

        tempButton.onClick.AddListener(delegate { UnequipItem(button, _inventoryUI.PlayerItemStorage.GetItem(GetId(button))); });
    }

    private void UpdateButtonGraphicsUnequip(GameObject button)
    {
        int id = int.Parse(button.name);
        CharacterItemButton characterItemButton = button.GetComponent<CharacterItemButton>();
        characterItemButton.SetInformation(_equipmentSlot[id].ItemImage, _equipmentSlot[id].ItemType.ToString());

        characterItemButton.ItemRarityShow.gameObject.SetActive(false);
        _equipmentSlot[id].SetId();

        Button temp = button.GetComponentInChildren<Button>();
        temp.onClick.RemoveAllListeners();
        temp.onClick.AddListener(delegate { EquipItem(_equipmentSlot[id].ItemType, button); });

        if(_equipmentSlot[id].ItemType == ItemType.Hand)
        {
            temp.onClick.AddListener(delegate { EquipItem(ItemType.Weapon, button, true); });
        }
    }

    private void EquipItem(ItemType type, GameObject button, bool isHand = false)
    {

        if (_inventoryUI.CurrentId != -1 && _inventoryUI.CurrentItemInventory.Item.Type == type)
        {
            Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id);

            UpdateButtonGraphicsEquip(button, item);

            if (_inventoryUI.InventoryStorage.GetItem(_inventoryUI.CurrentId).Id == 0)
            {
                _inventoryUI.InventoryStorage.TrySortingInventory(_inventoryUI.CurrentId, _inventoryUI.PlayerItemStorage);
            }

            _characterPlayerUI.EquipItem(type, true, item, isHand);

            _inventoryUI.ResetMovingObject();
        }
    }

    private void UnequipItem(GameObject button, Item item)
    {
        UpdateButtonGraphicsUnequip(button);
        int id = int.Parse(button.name);
        _characterPlayerUI.EquipItem(_equipmentSlot[id].ItemType, false, item);
        _inventoryUI.ReturnItem(item);
    }
}

[System.Serializable]

class SlotItems
{
    [SerializeField] private Sprite _itemImage;
    [SerializeField] private ItemType _itemType;

    public Sprite ItemImage => _itemImage;
    public ItemType ItemType => _itemType;
    public int ItemId { get; private set; }

    public void SetId(int id = 0)
    {
        ItemId = id;
    }
}
