using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInventoryData
{
    public int[] ItemsID;
    public int BagSize;
    public int PriceBagUp;

    public ItemInventoryData(InventoryStorage inventoryStorage)
    {
        ItemsID = new int[inventoryStorage.InventorySize];

        for(int i = 0; i < inventoryStorage.InventorySize; i++)
        {
            ItemsID[i] = inventoryStorage.GetItem(i).Item.Id;
        }

        PriceBagUp = inventoryStorage.PriceBagUp;
        BagSize = inventoryStorage.BagSize;
    }
}
