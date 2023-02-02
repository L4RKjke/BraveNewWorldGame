using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerItemStorage))]
[RequireComponent(typeof(InventoryStorage))]
[RequireComponent(typeof(ObjectMoverUI))]
public class InventoryUI : RenderUI
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CharactersItemUI _charactersItemUI;
    [SerializeField] private ItemDescriptionUI _itemDescriptionUI;

    private PlayerItemStorage _playerItemStorage;
    private InventoryStorage _inventoryStorage;
    private ObjectMoverUI _objectMoverUI;
    private int _currentId = -1;
    private ItemInventory _currentItem;

    public ItemDescriptionUI ItemDescriptionUI => _itemDescriptionUI;
    public InventoryStorage InventoryStorage => _inventoryStorage;
    public PlayerItemStorage PlayerItemStorage => _playerItemStorage;
    public ItemInventory CurrentItem => _currentItem;
    public int CurrentId => _currentId;
    public int MaxCount => _inventoryStorage.BagSize;

    private void Awake()
    {
        _inventoryStorage = GetComponent<InventoryStorage>();
        _playerItemStorage = GetComponent<PlayerItemStorage>();
        _objectMoverUI = GetComponent<ObjectMoverUI>();
        _objectMoverUI.Init(this, Container.GetComponent<RectTransform>().position.z);
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        AddGraphics();
        StartUpdateInventory();
    }

    public void ReturnItem(Item item = null)
    {
        ItemInventory temp = null;

        for (int i = 0; i < _inventoryStorage.InventorySize; i++)
        {
            if (_inventoryStorage.GetItem(i).Id == 0)
            {
                temp = _inventoryStorage.GetItem(i);
                break;
            }
        }

        if (item == null && _objectMoverUI.MovingObject.gameObject.activeSelf == true)
        {
            item = _playerItemStorage.GetItem(_currentItem.Id);
            _objectMoverUI.MoveSetActive(false);
            _currentId = -1;
        }

        if(item != null)
        _inventoryStorage.AddItem(int.Parse(temp.ItemObject.name), item);
    }

    public void ResetMovingObject()
    {
        _currentId = -1;
        _objectMoverUI.MoveSetActive(false);
    }

    public void SelectObject(int buttonID)
    {
        if (_currentId == -1)
        {
            if (_inventoryStorage.GetItem(buttonID).Id == 0)
                return;

            UpdateDescription(buttonID);

            _currentId = buttonID;
            _currentItem = CopyInventoryItem(_inventoryStorage.GetItem(_currentId));
            _objectMoverUI.MoveSetActive(true);
            _objectMoverUI.SetSprite(_playerItemStorage.GetItem(_inventoryStorage.GetItem(_currentId).Id).Image);

            _inventoryStorage.AddItem(_currentId, _playerItemStorage.GetItem(0));
        }
        else
        {
            if (buttonID != _currentId)
                AddInventoryItem(_currentId, _inventoryStorage.GetItem(buttonID));

            AddInventoryItem(buttonID, _currentItem);

            ResetMovingObject();
        }
    }

    public void UpdateDescription(int id)
    {
        _itemDescriptionUI.UpdateDescription(_playerItemStorage.GetItem(_inventoryStorage.GetItem(id).Id));
    }

    protected override void AddGraphics()
    {
        for (int i = _inventoryStorage.InventorySize; i < _inventoryStorage.BagSize; i++)
        {
            GameObject newItem = Instantiate(Content, Container.transform) as GameObject;

            newItem.GetComponent<InventoryDragAndDrop>().Init(this, _camera, _charactersItemUI);
            newItem.name = i.ToString();

            ItemInventory itemInventory = new();
            itemInventory.AssignGameObject(newItem);

            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
            newItem.GetComponentInChildren<RectTransform>().localPosition = Vector3.one;

            _inventoryStorage.AddSlot(itemInventory);
        }
    }

    private void AddInventoryItem(int id, ItemInventory inventoryItem)
    {
        Item temp = _playerItemStorage.GetItem(inventoryItem.Id);
        _inventoryStorage.GetItem(id).UpdateInformation(inventoryItem.Id, temp.Image,temp.Type);
    }

    private void StartUpdateInventory()
    {
        for(int i = 0; i < _inventoryStorage.InventorySize; i++)
        {
            Item temp = _playerItemStorage.GetItem(_inventoryStorage.GetItem(i).Id);
            _inventoryStorage.GetItem(i).AssignÑharacteristics(temp.Image, temp.Type);
        }
    }

    private ItemInventory CopyInventoryItem(ItemInventory oldItem)
    {
        ItemInventory newItem = new();

        newItem.AssignId(oldItem.Id);
        newItem.AssignGameObject(oldItem.ItemObject);
        newItem.AssignÑharacteristics(oldItem.Image, oldItem.Type);

        return newItem;
    }
}
