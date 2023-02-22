using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoadGame))]
public class Loader : MonoBehaviour
{
    private SaveLoadGame _game;

    private void Start()
    {
        _game = GetComponent<SaveLoadGame>();
        _game.Load();
    }
}
