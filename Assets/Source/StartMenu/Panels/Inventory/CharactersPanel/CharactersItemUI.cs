using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersItemUI : MonoBehaviour
{
    [SerializeField] private List<SlotItems> _equipmentSlot = new List<SlotItems>();
    [SerializeField] private GameObject _gameObjectShow;
    [SerializeField] private GameObject _charactersItemsContent;
    [SerializeField] private InventoryUI _inventoryUI;

    private List<GameObject> _equippedItems = new List<GameObject>();

    private InventoryStorage _inventoryStorage => _inventoryUI.InventoryStorage;
    private ItemStorage _itemStorage => _inventoryUI.ItemStorage;
    private int _currentId => _inventoryUI.CurrentId;
    private ItemInventory _currentItem => _inventoryUI.CurrentItem;

    private void Start()
    {
        AddGraphics();
    }

    public void AddItem(GameObject item)
    {
        _equippedItems.Add(item);
    }

    public void UpdateButtonGraphics(GameObject button)
    {
        int id = int.Parse(button.name);
        button.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _equipmentSlot[id].ItemImage;
        button.GetComponentInChildren<TMP_Text>().text = _equipmentSlot[id].ItemName;
        _equipmentSlot[id].SetId();

        Button temp = button.GetComponentInChildren<Button>();
        temp.onClick.RemoveAllListeners();
        temp.onClick.AddListener(delegate { EquipItem(_equipmentSlot[id].ItemName, button); });
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

    private void EquipItem(string type, GameObject button)
    {

        if (_currentId != -1 && _currentItem.Type == type)
        {

            button.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _currentItem.Image;
            button.GetComponentInChildren<TMP_Text>().text = _currentItem.Name;
            AddItem(_currentItem.ItemObject);

            Button temp = button.GetComponentInChildren<Button>();
            temp.onClick.RemoveAllListeners();
            SetIdSlot(button, _currentItem.Id);

            temp.onClick.AddListener(delegate { UnequipItem(button, _itemStorage.GetItem(GetId(button))); });

            if (_inventoryStorage.GetItem(_currentId).Id == 0)
            {
                bool needSorting = _inventoryStorage.CheckSorting();

                if (needSorting)
                    _inventoryStorage.SortingInventory(_currentId, _itemStorage);
            }

            _inventoryUI.ResetMovingObject();
        }
    }

    private void UnequipItem(GameObject button, Item item)
    {
        UpdateButtonGraphics(button);
        _inventoryUI.ReturnItem(item);
    }

    private void AddGraphics()
    {
        for (int i = 0; i < _equipmentSlot.Count; i++)
        {
            GameObject newButton = Instantiate(_gameObjectShow, _charactersItemsContent.transform) as GameObject;
            newButton.name = i.ToString();

            UpdateButtonGraphics(newButton);
        }
    }
}

[System.Serializable]

class SlotItems
{
    [SerializeField] private Sprite _itemImage;
    [SerializeField] private string _itemName;

    public Sprite ItemImage => _itemImage;
    public string ItemName => _itemName;
    public int ItemId;

    public void SetId(int id = 0)
    {
        ItemId = id;
    }
}
