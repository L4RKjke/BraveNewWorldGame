using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonimousSaver : MonoBehaviour
{
    [SerializeField] private SaveLoadGame _saveLoadGame;

    private void OnEnable()
    {
        _saveLoadGame.Saved += Save;
    }

    private void OnDisable()
    {
        _saveLoadGame.Saved -= Save;
    }

    private void Save()
    {
        _saveLoadGame.SaveBinnary();
    }
}
