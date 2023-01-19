using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : RenderUI
{
    [SerializeField] private List<SlotStat> _stats = new List<SlotStat>();

    private void Start()
    {
        AddGraphics();
    }

    protected override void AddGraphics()
    {
        for (int i = 0; i < _stats.Count; i++)
        {
            GameObject newStat = Instantiate(Ñontainer, Content.transform) as GameObject;
            newStat.name = i.ToString();

            newStat.transform.GetComponentInChildren<Image>().sprite = _stats[i].Image;
            UpdateStatText(i);
        }
    }

    private void UpdateStatNumber(int id, int count)
    {
        _stats[id].UpdateStat(count);
        UpdateStatText(id);
    }

    private void UpdateStatText(int id)
    {
        GameObject temp = Content.transform.GetChild(id).gameObject;
        temp.transform.GetComponentInChildren<TMP_Text>().text = _stats[id].Stat.ToString();
    }
}

[System.Serializable]

class SlotStat
{
    [SerializeField] private Sprite _image;
    [SerializeField] private int _stat;

    public int Stat => _stat;
    public Sprite Image => _image;

    public void UpdateStat(int number)
    {
        _stat += number;
    }
}

