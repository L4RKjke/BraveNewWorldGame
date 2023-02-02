using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForge : MonoBehaviour
{
    [SerializeField] private Sprite _standartSprite;

    private string _requireName = null;
    private int _requireLevel = 1;
    private int _itemID = -1;

    public string RequireName => _requireName;
    public int RequireLevel => _requireLevel;
    public int ItemID => _itemID;

    public void SetRequre(string name, int level)
    {
        _requireName = name;
        _requireLevel = level;
    }

    public void SetItemID(int id = -1)
    {
        _itemID = id;
    }

    public void SetSprite(Sprite sprite, Color color)
    {
        this.GetComponent<Image>().sprite = sprite;
    }

    public void ResetInfo()
    {
        SetRequre(null,1);
        SetSprite(_standartSprite, new Color(0, 0, 0, 255));
        SetItemID(-1);
    }
}
