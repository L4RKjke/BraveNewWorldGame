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

    private List<Item> _equippedItems = new List<Item>();

    private void Start()
    {
        AddGraphics();
    }

    private void AddGraphics()
    {
        for (int i = 0; i < _equipmentSlot.Count; i++)
        {
            GameObject newButton = Instantiate(_gameObjectShow, _charactersItemsContent.transform) as GameObject;

            newButton.GetComponentInChildren<Button>().onClick.AddListener(delegate { _inventoryUI.SelectObject(); });
            newButton.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _equipmentSlot[i].ItemImage;
            newButton.GetComponentInChildren<TMP_Text>().text = _equipmentSlot[i].ItemName;
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
}
