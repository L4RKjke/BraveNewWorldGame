using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemRaryti", menuName = "Other/Item/ItemRarity")]
public class ItemRarity : ScriptableObject
{
    [SerializeField] private List<Color> _colors;

    public Color GetColor(int id)
    {
        if(id >= _colors.Count)
        id = _colors.Count - 1;

        return _colors[id];
    }
}
