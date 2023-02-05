using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventorySizeUI : MonoBehaviour
{
    [SerializeField] private PlayerItemStorage _playerItemStorage;
    [SerializeField] private TMP_Text _textCount;

    private void OnEnable()
    {
        _playerItemStorage.ItemCountChange += ChangeText;
        ChangeText();
    }

    private void OnDisable()
    {
        _playerItemStorage.ItemCountChange -= ChangeText;
    }

    public void ChangeText()
    {
        _textCount.text = (_playerItemStorage.CountItems - 1 - _playerItemStorage.NullSlots).ToString() + "|" + _playerItemStorage.MaxSizeInventory;

        if (_playerItemStorage.MaxSizeInventory <= (_playerItemStorage.CountItems - 1 - _playerItemStorage.NullSlots))
            _textCount.color = Color.red;
        else
            _textCount.color = Color.white;
    }
}
