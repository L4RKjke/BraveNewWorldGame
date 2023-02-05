using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryButton : MonoBehaviour
{
    [SerializeField] private ButtonType _type;

    public ButtonType Type => _type;

    public enum ButtonType
    {
        Inventory,
        CharacterItem,
        Forge,
        Delete
    }
}
