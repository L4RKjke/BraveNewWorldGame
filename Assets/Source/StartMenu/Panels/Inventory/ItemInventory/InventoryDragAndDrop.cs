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
        Item item = _inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItem.Id);

        if (cell != null)
        {
            cell.TryGetComponent<InventoryButton>(out InventoryButton inventoryButton);

            if(inventoryButton != null)
            {
                switch(inventoryButton.Type)
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
                            else
                            {
                                ItemType itemType = _inventoryUI.CurrentItem.Type;
                                ItemType slotType = _charactersItemUI.GetType(cell.gameObject);

                                if (itemType == slotType || (itemType == ItemType.Weapon && slotType == ItemType.Hand))
                                {
                                    _inventoryUI.ItemDescriptionUI.UpdateDescription(item);
                                    button.onClick.Invoke();
                                    button.onClick.Invoke();
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
                            else
                            {
                                _inventoryUI.ItemDescriptionUI.UpdateDescription(item);
                                button.onClick.Invoke();
                                button.onClick.Invoke();
                            }
                        }
                        break;
                    case ButtonType.Delete:
                        {

                        }
                        break;
                }
            }          
        }

        if (_inventoryUI.CurrentId != -1)
        {
            _inventoryUI.PlayerItemStorage.ReturnItem(item);
            _inventoryUI.ResetMovingObject();
        }
    }

    public void Init(InventoryUI inventory, Camera camera, CharactersItemUI charactersItemUI)
    {
        _inventoryUI = inventory;
        _camera = camera;
        _charactersItemUI = charactersItemUI;
    }
}
