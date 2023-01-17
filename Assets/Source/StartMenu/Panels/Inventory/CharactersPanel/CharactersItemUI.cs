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
        temp.onClick.AddListener(delegate { _inventoryUI.EquipItem(_equipmentSlot[id].ItemName, button); });
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
