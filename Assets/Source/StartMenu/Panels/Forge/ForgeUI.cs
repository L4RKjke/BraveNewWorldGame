using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeUI : MonoBehaviour
{
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private List<GameObject> _buttonsForge;
    [SerializeField] private GameObject _buttonStartForge;
    [SerializeField] private GameObject _buttonNewitem;

    private void Start()
    {
        for (int i = 0; i < _buttonsForge.Count; i++)
        {
            _buttonsForge[i].GetComponent<Button>().onClick.AddListener(delegate { AddItem(_buttonsForge[i]); });
        }
    }

    private void AddItem(GameObject buttonObject)
    {
        Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentId);

        ButtonForge buttonForge = buttonObject.GetComponent<ButtonForge>();

        if(buttonForge.RequireName == null)
        {
            buttonForge.SetSprite(item.Image, new Color(0,0,0,255)) ;
            buttonForge.SetItemID(item.Id);

            ButtonForge buttonForge2 = GetSecondButton(buttonObject);
            AddInfoSecondButton(buttonForge2, item);

            _inventoryUI.ResetMovingObject();
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(delegate { ReturnItem(item.Id,buttonObject); });
        }
        else if (buttonForge.RequireName == item.Name && buttonForge.RequireLevel == item.Level)
        {
            buttonForge.SetSprite(item.Image, new Color(0, 0, 0, 255));

        }
    }

    private void ReturnItem(int id, GameObject buttonObject)
    {
        Item item = _inventoryUI.PlayerItemStorage.GetItem(id);
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
            AddInfoSecondButton(buttonForge, item);
            buttonForge.SetItemID();
        }
    }

    private void AddInfoSecondButton(ButtonForge buttonForge ,Item item)
    {
        buttonForge.SetRequre(item.Name, item.Level);
        buttonForge.SetSprite(item.Image, new Color(0, 0, 0, 150));
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

    private void ReturnNewItem(Item item)
    {

    }
}
