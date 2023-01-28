using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(PlayerItemStorage))]
[RequireComponent(typeof(InventoryStorage))]
public class InventoryUI : RenderUI
{
    [SerializeField] private RectTransform _movingObject;

    private PlayerItemStorage _playerItemStorage;
    private InventoryStorage _inventoryStorage;
    private int _maxCount = 25;
    private int _currentId = -1;
    private ItemInventory _currentItem;

    private Vector3 _offSet = new(1,-1,0);

    public InventoryStorage InventoryStorage => _inventoryStorage;
    public PlayerItemStorage PlayerItemStorage => _playerItemStorage;
    public ItemInventory CurrentItem => _currentItem;
    public int CurrentId => _currentId;
    public int MaxCount => _maxCount;


    public EventSystem _eventSystem;

    private void Awake()
    {
        _inventoryStorage = GetComponent<InventoryStorage>();
        _playerItemStorage = GetComponent<PlayerItemStorage>();
    }

    private void Start()
    {
        if (_inventoryStorage.InventorySize == 0)
            AddGraphics();


        Item item = _playerItemStorage.GetItem(0);
        _inventoryStorage.CreateInventory(_maxCount, item);


        for (int i = 1; i < _playerItemStorage.CountItems; i++)
        {
            Item NewItem = _playerItemStorage.GetItem(i);
            Debug.Log(NewItem);
            _inventoryStorage.AddItem(i - 1, NewItem);
        }


        StartUpdateInventory();
    }

    private void Update()
    {
        if(_currentId != -1)
            MoveObject();

    }

    public void ButtonReturnItem()
    {
        ReturnItem();
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

        if (item == null && _movingObject.gameObject.activeSelf == true)
        {
            item = _playerItemStorage.GetItem(_currentItem.Id);
            _movingObject.gameObject.SetActive(false);
            _currentId = -1;
        }

        if(item != null)
        _inventoryStorage.AddItem(int.Parse(temp.ItemObject.name), item);
    }

    public void ResetMovingObject()
    {
        _currentId = -1;
        _movingObject.gameObject.SetActive(false);
    }

    protected override void AddGraphics()
    {
        for (int i = _inventoryStorage.InventorySize; i < _maxCount; i++)
        {
            GameObject newItem = Instantiate(—ontainer, Content.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory itemInventory = new();
            itemInventory.AssignGameObject(newItem);

            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
            newItem.GetComponentInChildren<RectTransform>().localPosition = Vector3.one;

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            _inventoryStorage.AddSlot(itemInventory);
        }
    }

    private void SelectObject()
    {
        if (_currentId == -1)
        {
            if (_inventoryStorage.GetItem(int.Parse(_eventSystem.currentSelectedGameObject.name)).Id == 0)
                return;

            _currentId = int.Parse(_eventSystem.currentSelectedGameObject.name);
            _currentItem = CopyInventoryItem(_inventoryStorage.GetItem(_currentId));
            _movingObject.gameObject.SetActive(true);
            _movingObject.GetComponent<Image>().sprite = _playerItemStorage.GetItem(_inventoryStorage.GetItem(_currentId).Id).Image;

            _inventoryStorage.AddItem(_currentId, _playerItemStorage.GetItem(0));
        }
        else
        {
            ItemInventory temp = _inventoryStorage.GetItem(int.Parse(_eventSystem.currentSelectedGameObject.name));

            ReturnItem(_playerItemStorage.GetItem(temp.Id));

            AddInventoryItem(int.Parse(_eventSystem.currentSelectedGameObject.name), _currentItem);
            _currentId = -1;

            _movingObject.gameObject.SetActive(false);
        }
    }

    private void AddInventoryItem(int id, ItemInventory inventoryItem)
    {
        Item temp = _playerItemStorage.GetItem(inventoryItem.Id);
        _inventoryStorage.GetItem(id).UpdateInformation(inventoryItem.Id, temp.Image, temp.Name,temp.Type);
    }

    private void StartUpdateInventory()
    {
        for(int i = 0; i < _inventoryStorage.InventorySize; i++)
        {
            Item temp = _playerItemStorage.GetItem(_inventoryStorage.GetItem(i).Id);
            _inventoryStorage.GetItem(i).Assign—haracteristics(temp.Name, temp.Image, temp.Type);
        }
    }

    private void MoveObject()
    {
        Vector3 position = Input.mousePosition + _offSet;
        position.z = Content.GetComponent<RectTransform>().position.z;
        _movingObject.position = Camera.main.ScreenToWorldPoint(position);
    }

    private ItemInventory CopyInventoryItem(ItemInventory oldItem)
    {
        ItemInventory newItem = new();

        newItem.AssignId(oldItem.Id);
        newItem.AssignGameObject(oldItem.ItemObject);
        newItem.Assign—haracteristics(oldItem.Name, oldItem.Image, oldItem.Type);

        return newItem;
    }
}
