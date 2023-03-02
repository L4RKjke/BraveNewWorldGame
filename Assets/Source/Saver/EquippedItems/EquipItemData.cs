using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipItemData
{
    public int CountItems;
    public int[] ItemsID;
    public bool[] InHand;

    public void Init(int count)
    {
        ItemsID = new int[count];
        InHand = new bool[count];
    }

    public void SetId(int numberItem, int ID)
    {
        ItemsID[numberItem] = ID;
    }

    public void SetInHand(int numberItem, bool inHand)
    {
        InHand[numberItem] = inHand;
    }

    public void SetCount(int count)
    {
        CountItems = count;
    }
}
