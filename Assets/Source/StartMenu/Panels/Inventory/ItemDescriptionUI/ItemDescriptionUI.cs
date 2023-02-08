using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescriptionUI : StatsUI
{
    [SerializeField] private TMP_Text _itemDescription;

    private void Awake()
    {
        Init();
    }

    public void UpdateDescription(Item item)
    {
        if (item.Name != "")
        {
            UpdateAllStats(item.Attack, item.Defense, item.Health, item.Magic);
            UpdateName(item.Name, item.Type.ToString(), item.Level);
        }
    }

    private void UpdateName(string name, string type, int level)
    {
        _itemDescription.text = name + " : " + type + " LVL - " + level;
    }
}
