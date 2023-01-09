using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    [SerializeField] private SpriteRenderer _sprite;

    private void Start()
    {
        int random = Random.Range(0, _sprites.Length);

        _sprite.sprite = _sprites[random];
    }
}
