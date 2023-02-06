using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public int Level { get; private set; }
    public string Type { get; private set; }
    public int SearchID { get; private set; }

    public ItemData(Item item)
    {
        Level = item.Level;
        Type = item.Type.ToString();
        SearchID = item.SearchID;
    }
}
