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

    public void UpdateAllStats(int attack,int defense, int life)
    {
        UpdateStatText(0, attack);
        UpdateStatText(1, defense);
        UpdateStatText(2, life);
        UpdateStatText(3, Random.Range(0,100));
    }

    public void UpdateName(string name)
    {
        _name.text = name;
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _stats.Count; i++)
        {
            GameObject newStat = Instantiate(Ñontainer, Content.transform) as GameObject;
            newStat.name = i.ToString();

            newStat.transform.GetComponentInChildren<Image>().sprite = _stats[i].Image;
        }
    }

    private void UpdateStatText(int id, int stat)
    {
        GameObject temp = Content.transform.GetChild(id).gameObject;
        temp.transform.GetComponentInChildren<TMP_Text>().text = stat.ToString();
    }
}

[System.Serializable]

class SlotStat
{
    [SerializeField] private Sprite _image;
    [SerializeField] private int _stat;

    public int Stat => _stat;
    public Sprite Image => _image;
}

