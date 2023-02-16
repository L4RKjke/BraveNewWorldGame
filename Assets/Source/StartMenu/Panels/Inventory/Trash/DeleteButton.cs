using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : InventoryButton
{
    [SerializeField] private PlayerItemStorage _playerItemStorage;

    public void DeleteItem(int id)
    {
        _playerItemStorage.DeleteItem(id);
    }
}
