using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInventoryData
{ 
    public int[] ItemsID { get; private set; }
    public int BagSize { get; private set; }
    public int PriceBagUp { get; private set; }

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
