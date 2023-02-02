using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionUI : StatsUI
{
    [SerializeField] private TMP_Text _itemDescription;

    public void UpdateDescription(Item item)
    {
        UpdateAllStats(item.Attack, item.Defense, item.Health, item.Magic);
        UpdateName(item.Name, item.Type.ToString(), item.Level);
    }

    private void UpdateName(string name, string type, int level)
    {
        _itemDescription.text = name + " : " + type + " LVL - " + level;
    }
}
