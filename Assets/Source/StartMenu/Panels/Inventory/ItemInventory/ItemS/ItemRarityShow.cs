using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRarityShow : MonoBehaviour
{
    [SerializeField] private Image _rarity;

    public void SetRarity(Color color)
    {
        _rarity.color = color;
    }
}
