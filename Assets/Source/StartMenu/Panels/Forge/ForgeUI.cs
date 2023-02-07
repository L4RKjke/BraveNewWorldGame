using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeUI : MonoBehaviour
{
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private List<GameObject> _buttonsForge;
    [SerializeField] private Button _buttonStartForge;
    [SerializeField] private Button _buttonNewItem;
    [SerializeField] private StatsUI _statsUI;
    [SerializeField] private GameObject _statsContainer;
    [SerializeField] private FillBarForge _fillBarNewItem;

    private int _itemId1;
    private int _itemId2;

    private void Start()
    {
        for (int i = 0; i < _buttonsForge.Count; i++)
        {
            GameObject button = _buttonsForge[i];
            _buttonsForge[i].GetComponent<Button>().onClick.AddListener(delegate { AddItem(button); });
        }
    }

    private void OnDisable()
    {
        CheckForgingNewItem();

        for (int i = 0; i < _buttonsForge.Count; i++)
        {
            if (_buttonsForge[i].GetComponent<ButtonForge>().ItemID != -1)
                _buttonsForge[i].GetComponent<Button>().onClick.Invoke();
        }

        if (_buttonNewItem.transform.GetChild(0).GetComponent<Image>() != null)
            _buttonNewItem.onClick.Invoke();
    }

    private void CheckForgingNewItem()
    {
        if (_fillBarNewItem.Fill.fillAmount > 0 && _fillBarNewItem.Fill.fillAmount < 1)
        {
            _fillBarNewItem.OffFill();
            _fillBarNewItem.FillEnd -= ForgeComplete;
        }
    }

    private void AddItem(GameObject buttonObject)
    {
        if (_inventoryUI.CurrentId != -1)
        {
            Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id);

            ButtonForge buttonForge = buttonObject.GetComponent<ButtonForge>();

            if (buttonForge.RequireName == null)
            {
                Color color = _inventoryUI.ItemRarity.GetColor(item.Level - 1);
                buttonForge.StartFill(color);
                ButtonForge buttonForge2 = GetSecondButton(buttonObject);
                AddInfoSecondButton(buttonForge2, item);
                AddListenerReturn(item, buttonObject);
            }
            else if (buttonForge.RequireName == item.Name && buttonForge.RequireLevel == item.Level)
            {
                Color color = _inventoryUI.ItemRarity.GetColor(item.Level - 1);
                buttonForge.StartFill(color);
                ButtonForge buttonForge2 = GetSecondButton(buttonObject);
                AddListenerReturn(item, buttonObject);
                _buttonStartForge.onClick.AddListener(delegate { StartForge(item.Id, buttonForge2.ItemID); });
                _buttonStartForge.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                _inventoryUI.ResetMovingObject();
                _inventoryUI.ReturnItem(item);
            }
        }
    }

    private void AddListenerReturn(Item item, GameObject buttonObject)
    {
        _inventoryUI.ResetMovingObject();
        ButtonForge buttonForge = buttonObject.GetComponent<ButtonForge>();
        buttonForge.SetSprite(item.Image, Color.white);
        buttonForge.SetItemID(item.Id);
        Button button = buttonObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { ReturnItem(item, buttonObject); });
    }

    private void StartForge(int itemId1, int itemId2)
    {
        _itemId1 = itemId1;
        _itemId2 = itemId2;

        Image newItemImage = _buttonNewItem.transform.GetChild(0).GetComponent<Image>();

        if (newItemImage.sprite == null)
        {
            Item item = _inventoryUI.PlayerItemStorage.GetItem(itemId1);
            Color color = _inventoryUI.ItemRarity.GetColor(item.Level);
            _fillBarNewItem.StartFill(color);
            _buttonStartForge.onClick.RemoveAllListeners();
            _fillBarNewItem.FillEnd += ForgeComplete;
        }
    }

    private void ForgeComplete()
    {
        Image newItemImage = _buttonNewItem.transform.GetChild(0).GetComponent<Image>();
        Item item = _inventoryUI.PlayerItemStorage.GetItem(_itemId1);
        _buttonStartForge.transform.GetChild(1).gameObject.SetActive(true);
        Item newItem = Instantiate(item);
        newItem.SetLevel(item.Level + 1);
        _statsContainer.SetActive(true);
        _statsUI.UpdateAllStats(item.Attack / item.Level, item.Defense / item.Level, item.Health / item.Level, item.Magic / item.Level, true);
        _inventoryUI.PlayerItemStorage.DeleteItem(_itemId1);
        _inventoryUI.PlayerItemStorage.DeleteItem(_itemId2);
        newItem.SetSearchID(item.SearchID);
        ItemData itemData = new ItemData(newItem);
        _buttonNewItem.onClick.AddListener(delegate { ReturnNewItem(newItem, itemData); });
        newItemImage.sprite = newItem.Image;
        newItemImage.color = Color.white;
        ResetButtonsForge();
        _itemId1 = 0;
        _fillBarNewItem.FillEnd -= ForgeComplete;
    }

    private void ReturnItem(Item item, GameObject buttonObject)
    {
        _inventoryUI.ReturnItem(item);
        ButtonForge buttonForge = buttonObject.GetComponent<ButtonForge>();
        buttonForge.ResetInfo();
        Button button = buttonObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { AddItem(buttonObject); });

        ButtonForge buttonForge2 = GetSecondButton(buttonObject);

        if (buttonForge2.ItemID == -1)
        {
            buttonForge2.ResetInfo();
        }
        else
        {
            _buttonStartForge.transform.GetChild(1).gameObject.SetActive(true);
            _buttonStartForge.onClick.RemoveAllListeners();
            AddInfoSecondButton(buttonForge, item);
            buttonForge.SetItemID();
            CheckForgingNewItem();
        }
    }

    private void AddInfoSecondButton(ButtonForge buttonForge ,Item item)
    {
        buttonForge.SetRequre(item.Name, item.Level);
        buttonForge.SetSprite(item.Image, Color.red);
    }

    private ButtonForge GetSecondButton (GameObject button1)
    {
        ButtonForge buttonForge = null;

        for (int i = 0; i < _buttonsForge.Count; i++)
        {
            if (_buttonsForge[i] != button1)
            {
                buttonForge = _buttonsForge[i].GetComponent<ButtonForge>();
                return buttonForge;
            }
        }

        return buttonForge;
    }

    private void ResetButtonsForge()
    {
        Button button;
        ButtonForge buttonForge;

        for (int i = 0; i < _buttonsForge.Count; i++)
        {
            button = _buttonsForge[i].GetComponent<Button>();
            buttonForge = _buttonsForge[i].GetComponent<ButtonForge>();
            button.onClick.RemoveAllListeners();
            GameObject gameObject = _buttonsForge[i];
            button.onClick.AddListener(delegate { AddItem(gameObject); });
            buttonForge.ResetInfo();
        }
    }

    private void ReturnNewItem(Item item, ItemData itemData)
    {
        bool isAddSuccec = _inventoryUI.PlayerItemStorage.TryAddItem(item, itemData);

        if (isAddSuccec)
        {
            _statsContainer.SetActive(false);
            _buttonNewItem.onClick.RemoveAllListeners();
            _buttonNewItem.transform.GetChild(0).GetComponent<Image>().sprite = null;
            _buttonNewItem.transform.GetChild(0).GetComponent<Image>().color = Color.clear;
            _fillBarNewItem.OffFill();
        }
    }
}
