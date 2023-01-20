using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersItemUI : RenderUI
{
    [SerializeField] private List<SlotItems> _equipmentSlot = new List<SlotItems>();
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private CharacterPlayerUI _characterPlayerUI;

    private InventoryStorage _inventoryStorage => _inventoryUI.InventoryStorage;
    private ItemStorage _itemStorage => _inventoryUI.ItemStorage;
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

            GameObject button = Content.transform.GetChild(i).gameObject;

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
            GameObject newButton = Instantiate(Ñontainer, Content.transform) as GameObject;
            newButton.name = i.ToString();

            UpdateButtonGraphicsUnequip(newButton);
        }
    }

    private void UpdateButtonGraphicsEquip(GameObject button, Item item)
    {

        button.transform.GetChild(0).GetComponentInChildren<Image>().sprite = item.Image;
        button.GetComponentInChildren<TMP_Text>().text = item.Name;

        Button tempButton = button.GetComponentInChildren<Button>();
        tempButton.onClick.RemoveAllListeners();
        SetIdSlot(button, item.Id);

        tempButton.onClick.AddListener(delegate { UnequipItem(button, _itemStorage.GetItem(GetId(button))); });
    }

    private void UpdateButtonGraphicsUnequip(GameObject button)
    {
        int id = int.Parse(button.name);
        button.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _equipmentSlot[id].ItemImage;
        button.GetComponentInChildren<TMP_Text>().text = _equipmentSlot[id].ItemType.ToString();
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

        if (_currentId != -1 && _currentItem.Type == type)
        {
            Item item = _itemStorage.GetItem(_currentItem.Id);

            UpdateButtonGraphicsEquip(button, item);

            if (_inventoryStorage.GetItem(_currentId).Id == 0)
            {
                bool needSorting = _inventoryStorage.CheckSorting();

                if (needSorting)
                    _inventoryStorage.SortingInventory(_currentId, _itemStorage);
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
