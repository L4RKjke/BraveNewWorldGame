using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryStorage _inventoryStorage;
    [SerializeField] private GameObject _inventoryContent;
    [SerializeField] private GameObject _gameObjectShow;
    [SerializeField] private RectTransform _movingObject;
    [SerializeField] private CharactersItemUI _charactersItemUI;

    private List<ItemInventory> _items = new List<ItemInventory>();
    private int _maxCount = 50;

    private int _currentId = -1;
    private ItemInventory _currentItem;

    private Vector3 _offSet = new Vector3(1,-1,0);

    public EventSystem _eventSystem;

    private void Start()
    {
        if (_items.Count == 0)
            AddGraphics();

        for(int i = 0; i < _maxCount; i++) // test
        {
            int random = Random.Range(1, _inventoryStorage.CountItems);
            Item item = _inventoryStorage.GetItem(random);
            AddItem(i, item);
        }

        StartUpdateInventory();
    }

    private void Update()
    {
        if(_currentId != -1)
            MoveObject();

    }

    public void EquipItem(string type, GameObject button)
    {

        if (_currentId != -1 && _currentItem.Type == type)
        {

            button.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _currentItem.Image;
            button.GetComponentInChildren<TMP_Text>().text = _currentItem.Name;
            _charactersItemUI.AddItem(_currentItem.ItemObject);

            Button temp = button.GetComponentInChildren<Button>();
            temp.onClick.RemoveAllListeners();
            _charactersItemUI.SetIdSlot(button, _currentItem.Id);

            temp.onClick.AddListener(delegate { UnequipItem(button, _inventoryStorage.GetItem(_charactersItemUI.GetId(button))); });

            if (_items[_currentId].Id == 0)
            UpdateInventory(_currentId);

            _currentId = -1;
            _movingObject.gameObject.SetActive(false);
        }
    }

    public void UnequipItem(GameObject button, Item item)
    {
        _charactersItemUI.UpdateButtonGraphics(button);
        ReturnItem(item);
    }

    private void ReturnItem(Item item)
    {
        ItemInventory temp = null;
        Debug.Log(item);

        foreach (var itemInventory in _items)
        {
            if(itemInventory.Id == 0)
            {
                 temp = itemInventory;
                break;
            }
        }
        AddItem(int.Parse(temp.ItemObject.name), item);
    }

    private void UpdateInventory(int startId)
    {
        for (int i = startId; i < _items.Count; i++)
        {
            if (i < _items.Count - 1)
            {
                AddItem(i, _inventoryStorage.GetItem(_items[i + 1].Id));
            }
            else
            {
                AddItem(i, _inventoryStorage.GetItem(0));
            }
        }
    }

    private void SelectObject()
    {
        if (_currentId == -1)
        {
            _currentId = int.Parse(_eventSystem.currentSelectedGameObject.name);
            _currentItem = CopyInventoryItem(_items[_currentId]);
            _movingObject.gameObject.SetActive(true);
            _movingObject.GetComponent<Image>().sprite = _inventoryStorage.GetItem(_items[_currentId].Id).Image;

            AddItem(_currentId, _inventoryStorage.GetItem(0));
        }
        else
        {
            ItemInventory temp = _items[int.Parse(_eventSystem.currentSelectedGameObject.name)];

            AddInventoryItem(_currentId, temp);
            AddInventoryItem(int.Parse(_eventSystem.currentSelectedGameObject.name), _currentItem);
            _currentId = -1;

            _movingObject.gameObject.SetActive(false);
        }
    }

    private void AddItem(int id, Item item)
    {
        _items[id].UpdateInformation(item.Id, item.Image, item.Name, item.Type);
    }

    private void AddInventoryItem(int id, ItemInventory inventoryItem)
    {
        Item temp = _inventoryStorage.GetItem(inventoryItem.Id);
        _items[id].UpdateInformation(inventoryItem.Id, temp.Image, temp.Name,temp.Type);
    }

    private void AddGraphics()
    {
        for(int i = _items.Count; i < _maxCount; i++)
        {
            GameObject newItem = Instantiate(_gameObjectShow, _inventoryContent.transform) as GameObject;

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

    private void StartUpdateInventory()
    {
        for(int i = 0; i < _items.Count; i++)
        {
            Item temp = _inventoryStorage.GetItem(_items[i].Id);
            _items[i].Assign—haracteristics(temp.Name, temp.Image, temp.Type);
        }
    }

    private void MoveObject()
    {
        Vector3 position = Input.mousePosition + _offSet;
        position.z = _inventoryContent.GetComponent<RectTransform>().position.z;
        _movingObject.position = Camera.main.ScreenToWorldPoint(position);
    }

    private ItemInventory CopyInventoryItem(ItemInventory oldItem)
    {
        ItemInventory newItem = new ItemInventory();

        newItem.AssignId(oldItem.Id);
        newItem.AssignGameObject(oldItem.ItemObject);
        newItem.Assign—haracteristics(oldItem.Name, oldItem.Image, oldItem.Type);

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
    public string Type { get; private set; }
    public int Id => _id;


    public void AssignGameObject(GameObject item)
    {
        _itemObject = item;
    }

    public void AssignId(int id)
    {
        _id = id;
    }

    public void Assign—haracteristics(string name, Sprite image, string type)
    {
        Name = name;
        _itemObject.GetComponentInChildren<TMP_Text>().text = Name;

        Image = image;
        _itemObject.GetComponent<Image>().sprite = Image;

        Type = type;
    }

    public void UpdateInformation(int id, Sprite image, string name, string type)
    {
        AssignId(id);
        Assign—haracteristics(name, image, type);
    }
}
