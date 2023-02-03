using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryDragAndDrop : MonoBehaviour
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
            if (cell.GetComponent<InventoryDragAndDrop>() != null)
            {
                _inventoryUI.SelectObject(int.Parse(cell.gameObject.name));
            }
            else if(cell.GetComponent<ButtonForge>() != null)
            {
                Button button = cell.GetComponentInChildren<Button>();
                button.onClick.Invoke();
            }
            else
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
                        button.onClick.Invoke();
                        button.onClick.Invoke();
                    }
                }
            }
        }

        if (_inventoryUI.CurrentId != -1)
        {
            _inventoryUI.PlayerItemStorage.ReturnItem(_inventoryUI.PlayerItemStorage.GetItem(_inventoryUI.CurrentItem.Id));
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
