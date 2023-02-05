using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersItemUI : RenderUI
{
    [SerializeField] private List<SlotItems> _equipmentSlot = new List<SlotItems>();
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;

    private InventoryStorage _inventoryStorage => _inventoryUI.InventoryStorage;
    private PlayerItemStorage _itemStorage => _inventoryUI.PlayerItemStorage;
    private int _currentId => _inventoryUI.CurrentId;
    private ItemInventory _currentItem => _inventoryUI.CurrentItem;

    private void Awake()
    {
        AddGraphics();
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

        tempButton.onClick.AddListener(delegate { UnequipItem(button, _itemStorage.GetItem(GetId(button))); });
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

        if (_currentId != -1 && _currentItem.Item.Type == type)
        {
            Item item = _itemStorage.GetItem(_currentItem.Id);

            UpdateButtonGraphicsEquip(button, item);

            if (_inventoryStorage.GetItem(_currentId).Id == 0)
            {
                _inventoryStorage.TrySortingInventory(_currentId, _itemStorage);
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
