using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryDragAndDrop : InventoryButton
{
    private CharactersItemUI _charactersItemUI;
    private InventoryUI _inventoryUI;
    private Button _button;
    private Camera _camera;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    private void OnMouseDown()
    {
        if (_inventoryUI.CurrentId == -1)
            _inventoryUI.SelectObject(int.Parse(_button.name));
    }

    private void OnMouseEnter()
    {
        if (_inventoryUI.CurrentId == -1)
            _inventoryUI.UpdateDescription(int.Parse(this.name));

    }

    private void OnMouseUp()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Collider2D cell = Physics2D.OverlapPoint(mousePosition);

        if (cell != null)
        {
            cell.TryGetComponent<InventoryButton>(out InventoryButton inventoryButton);

            if (inventoryButton != null)
            {
                switch (inventoryButton.Type)
                {
                    case ButtonType.Inventory:
                        {
                            _inventoryUI.SelectObject(int.Parse(cell.gameObject.name));
                        }
                        break;
                    case ButtonType.CharacterItem:
                        {
                            int id = _charactersItemUI.GetId(cell.gameObject);

                            Button button = cell.GetComponentInChildren<Button>();

                            if (id == 0)
                            {
                                button.onClick.Invoke();
                            }
                            else if(_inventoryUI.CurrentItemInventory != null)
                            {
                                ItemType itemType = _inventoryUI.CurrentItemInventory.Item.Type;
                                ItemType slotType = _charactersItemUI.GetType(cell.gameObject);

                                if (itemType == slotType || (itemType == ItemType.Weapon && slotType == ItemType.Hand))
                                {
                                    DoubleButtonClick(button);
                                }
                            }
                        }
                        break;
                    case ButtonType.Forge:
                        {
                            Button button = cell.GetComponentInChildren<Button>();
                            ButtonForge buttonForge = cell.GetComponent<ButtonForge>();

                            if (buttonForge.ItemID == -1)
                            {
                                button.onClick.Invoke();
                            }
                            else if (_inventoryUI.CurrentItemInventory != null)
                            {
                                DoubleButtonClick(button);
                            }
                        }
                        break;
                    case ButtonType.Delete:
                        {
                            cell.GetComponent<DeleteButton>().DeleteItem(_inventoryUI.CurrentItemInventory.Item.Id);
                            _inventoryUI.ResetMovingObject();
                        }
                        break;
                    case ButtonType.AllCharactersItems:
                        {
                            AllCharactersItems button = cell.GetComponentInChildren<AllCharactersItems>();
                            button.SetCurrentItem();
                        }
                        break;
                }
            }
        }

        if (_inventoryUI.CurrentId != -1)
        {
            if (cell != null)
            {
                Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id);
                _inventoryUI.PlayerItemStorage.ReturnItem(item);
            }
            else
            {
                _inventoryUI.SelectObject(int.Parse(_button.name));
            }

            _inventoryUI.ResetMovingObject();
        }
    }

    public void Init(InventoryUI inventory, Camera camera, CharactersItemUI charactersItemUI)
    {
        _inventoryUI = inventory;
        _camera = camera;
        _charactersItemUI = charactersItemUI;
    }

    private void DoubleButtonClick(Button button)
    {
        Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItemInventory.Id);
        _inventoryUI.ItemDescriptionUI.UpdateDescription(item);
        button.onClick.Invoke();
        button.onClick.Invoke();
    }
}
