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

    private void Start()
    {
        for (int i = 0; i < _buttonsForge.Count; i++)
        {
            GameObject button = _buttonsForge[i];
            _buttonsForge[i].GetComponent<Button>().onClick.AddListener(delegate { AddItem(button); });
        }
    }

    private void AddItem(GameObject buttonObject)
    {
        if (_inventoryUI.CurrentId != -1)
        {
            Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItem.Id);

            ButtonForge buttonForge = buttonObject.GetComponent<ButtonForge>();

            if (buttonForge.RequireName == null)
            {
                ButtonForge buttonForge2 = GetSecondButton(buttonObject);
                AddInfoSecondButton(buttonForge2, item);
                AddListenerReturn(item, buttonObject);
            }
            else if (buttonForge.RequireName == item.Name && buttonForge.RequireLevel == item.Level)
            {
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
        buttonForge.SetSprite(item.Image, new Color(255, 255, 255, 255));
        buttonForge.SetItemID(item.Id);
        Button button = buttonObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { ReturnItem(item, buttonObject); });
    }

    private void StartForge(int itemId1, int itemId2)
    {
        Image newItemImage = _buttonNewItem.transform.GetChild(0).GetComponent<Image>();

        if (newItemImage.sprite == null)
        {
            _buttonStartForge.transform.GetChild(1).gameObject.SetActive(true);
            _buttonStartForge.onClick.RemoveAllListeners();
            Item newItem = Instantiate(_inventoryUI.PlayerItemStorage.GetItem(itemId1));
            newItem.SetLevel(_inventoryUI.PlayerItemStorage.GetItem(itemId1).Level + 1);
            _inventoryUI.PlayerItemStorage.DeleteItem(itemId1);
            _inventoryUI.PlayerItemStorage.DeleteItem(itemId2);
            _buttonNewItem.onClick.AddListener(delegate { ReturnNewItem(newItem); });
            newItemImage.sprite = newItem.Image;
            newItemImage.color = new Color(255, 255, 255, 255);
            ResetButtonsForge();
        }
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
        }
    }

    private void AddInfoSecondButton(ButtonForge buttonForge ,Item item)
    {
        buttonForge.SetRequre(item.Name, item.Level);
        buttonForge.SetSprite(item.Image, new Color(255, 0, 0, 225));
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

    private void ReturnNewItem(Item item)
    {
        int id = _inventoryUI.PlayerItemStorage.GetFreeId();
        item.SetId(id);

        if (id == _inventoryUI.PlayerItemStorage.CountItems)
        {
            _inventoryUI.PlayerItemStorage.AddItem(item);
        }
        else
        {
            _inventoryUI.PlayerItemStorage.ChangeItem(item, id);
            _inventoryUI.ReturnItem(item);
        }

        _buttonNewItem.onClick.RemoveAllListeners();
        _buttonNewItem.transform.GetChild(0).GetComponent<Image>().sprite = null;
        _buttonNewItem.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
