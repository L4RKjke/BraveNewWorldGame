using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : RenderUI
{
    [SerializeField] private List<SlotStat> _stats = new List<SlotStat>();
    [SerializeField] private TMP_Text _name;

    private void Awake()
    {
        AddGraphics();
    }

    public void UpdateAllStats(int attack,int defense, int life, int magicPower, bool isForge = false)
    {
        if(isForge == false)
        {
            UpdateStatText(0, attack);
            UpdateStatText(1, defense);
            UpdateStatText(2, life);
            UpdateStatText(3, magicPower);
        }
        else
        {
            UpdateStatForge(0, attack);
            UpdateStatForge(1, defense);
            UpdateStatForge(2, life);
            UpdateStatForge(3, magicPower);
        }
    }

    public void UpdateName(string name)
    {
        _name.text = name;
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _stats.Count; i++)
        {
            GameObject newStat = Instantiate(Content, Container.transform) as GameObject;
            newStat.name = i.ToString();

            newStat.transform.GetComponentInChildren<Image>().sprite = _stats[i].Image;
        }
    }

    private void UpdateStatForge(int id, int stat)
    {
        TMP_Text text = Container.transform.GetChild(id).GetComponentInChildren<TMP_Text>();

        if (stat > 0)
        {
            text.text = "+" + stat.ToString();
            text.color = new Color(0, 255, 0, 255);
        }
        else if (stat < 0)
        {
            text.color = new Color(255, 0, 0, 255);
            text.text = stat.ToString();
        }
        else
        {
            text.color = new Color(255, 255, 255, 255);
            text.text = stat.ToString();
        }
    }

    private void UpdateStatText(int id, int stat)
    {
        GameObject temp = Container.transform.GetChild(id).gameObject;
        temp.transform.GetComponentInChildren<TMP_Text>().text = stat.ToString();
    }
}

[System.Serializable]

class SlotStat
{
    [SerializeField] private Sprite _image;

    public Sprite Image => _image;
}

