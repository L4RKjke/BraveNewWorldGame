using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventorySaveLoad : MonoBehaviour, BinarrySaveLoad
{
    [SerializeField] private InventoryUI _inventoryUI;

    public void Load()
    {
        ItemInventoryData itemInventoryData = BinarySavingSystem.LoadItemInventory();

        _inventoryUI.InventoryStorage.UpgradeLoad(itemInventoryData.BagSize, itemInventoryData.PriceBagUp);

        for (int i = 0; i < itemInventoryData.ItemsID.Length; i++)
        {
            _inventoryUI.InventoryStorage.AddItem(i, _inventoryUI.PlayerItemStorage.GetItem(itemInventoryData.ItemsID[i]));
        }
    }

    public void Save()
    {
        BinarySavingSystem.SaveItemInventory(_inventoryUI.InventoryStorage);
    }
}
