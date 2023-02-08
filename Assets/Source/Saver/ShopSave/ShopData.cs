using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{
    public int[] ItemSearchID;
    public bool[] IsSold;
    public string[] Type;

    public ShopData(ItemShopUI itemShop)
    {
        Transform container = itemShop.ShopContainer.transform;
        ItemSearchID = new int[container.childCount];
        IsSold = new bool[container.childCount];
        Type = new string[container.childCount];

        for (int i = 0; i < container.childCount; i++)
        {
            if (container.GetChild(i).GetComponentInChildren<Item>() != null)
            {
                ItemSearchID[i] = container.GetChild(i).GetComponentInChildren<Item>().SearchID;
                Type[i] = container.GetChild(i).GetComponentInChildren<Item>().Type.ToString();
            }
            else
            {
                IsSold[i] = true;
            }
        }
    }
}
