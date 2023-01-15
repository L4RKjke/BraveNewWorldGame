using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryStorage _inventoryStorage;
    [SerializeField] private GameObject _inventoryMainObject;
    [SerializeField] private GameObject _gameObjectShow;

    private List<ItemInventory> _items = new List<ItemInventory>();
    private int _maxCount;

    private int _currentId;
    private ItemInventory _currentItem;

    private RectTransform _movingObject;
    private Vector3 _offSet;

    public EventSystem _eventSystem;

    private void AddItem(int id, Item item)
    {
        _items[id].UpdateInformation(item.Id, item.Image, item.Name);
    }

    private void AddInventoryItem(int id, ItemInventory inventoryItem)
    {
        Item temp = _inventoryStorage.GetItem(inventoryItem.Id);
        _items[id].UpdateInformation(inventoryItem.Id, temp.Image, temp.Name);
    }

    private void AddGraphics()
    {
        for(int i = 0; i < _maxCount; i++)
        {
            GameObject newItem = Instantiate(_gameObjectShow, _inventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory itemInventory = new ItemInventory();
            itemInventory.AssignGameObject(newItem);

            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
            newItem.GetComponentInChildren<RectTransform>().localPosition = Vector3.one;

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            _items.Add(itemInventory);
        }
    }

    private void SelectObject()
    {
        if (_currentId == 1)
        {
            _currentId = int.Parse(_eventSystem.currentSelectedGameObject.name);
            _currentItem = CopyInventoryItem(_items[_currentId]);
            _movingObject.gameObject.SetActive(true);
            _movingObject.GetComponent<Image>().sprite = _inventoryStorage.GetItem(_currentId).Image;

            AddItem(_currentId, _inventoryStorage.GetItem(0));
        }
        else
        {
            AddInventoryItem(_currentId, _items[int.Parse(_eventSystem.currentSelectedGameObject.name)]);

            AddInventoryItem(int.Parse(_eventSystem.currentSelectedGameObject.name), _currentItem);
            _currentId = -1;

            _movingObject.gameObject.SetActive(false);
        }
    }

    private void UpdateInventory()
    {
        for(int i = 0; i < _maxCount; i++)
        {
            _items[i].AssignImage(_inventoryStorage.GetItem(_items[i].Id).Image);
            _items[i].AssignName(_inventoryStorage.GetItem(_items[i].Id).Name);
        }
    }

    private void MoveObject()
    {
        Vector3 position = Input.mousePosition + _offSet;
        position.z = _inventoryMainObject.GetComponent<RectTransform>().position.z;
        _movingObject.position = Camera.main.ScreenToWorldPoint(position);
    }

    private ItemInventory CopyInventoryItem(ItemInventory oldItem)
    {
        ItemInventory newItem = new ItemInventory();

        newItem.AssignId(oldItem.Id);
        newItem.AssignGameObject(oldItem.ItemObject);

        return newItem;
    }
}

[System.Serializable]

public class ItemInventory
{
    [SerializeField] private int _id;
    [SerializeField] private GameObject _itemObject;

    public GameObject ItemObject => _itemObject;
    public Sprite Image { get; private set; }
    public string Name { get; private set; }
    public int Id => _id;


    public void AssignGameObject(GameObject item)
    {
        _itemObject = item;
    }

    public void AssignId(int id)
    {
        _id = id;
    }

    public void AssignName(string name)
    {
        Name = name;
        _itemObject.GetComponentInChildren<TMP_Text>().text = Name;
    }

    public void AssignImage(Sprite image)
    {
        Image = image;
        _itemObject.GetComponent<Image>().sprite = Image;
    }

    public void UpdateInformation(int id, Sprite image, string name)
    {
        AssignId(id);
        AssignImage(image);
        AssignName(name);
    }
}
