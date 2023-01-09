using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsLayer : MonoBehaviour
{
    [SerializeField] private Cell _cell;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _minArenaY;

    private float _cellYHeight;

    private void Start()
    {
        _cellYHeight = _cell.transform.localScale.y;
        GetLayer();
    }

    protected void GetLayer()
    {
        int layer;
        layer = (int)(((transform.position.y - _minArenaY) / _cellYHeight) + 1);
        _sprite.sortingOrder = -layer;
        Debug.Log(layer);
    }
}
