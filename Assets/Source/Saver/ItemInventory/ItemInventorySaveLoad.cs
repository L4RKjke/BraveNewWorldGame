using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventorySaveLoad : MonoBehaviour, BinarrySaves
{
    [SerializeField] private InventoryUI _inventoryUI;

    public void Load(ItemInventoryData itemInventoryData)
    {
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

    public ItemInventoryData GetData()
    {
        ItemInventoryData itemInventory = new ItemInventoryData(_inventoryUI.InventoryStorage);

        return itemInventory;
    }
}
