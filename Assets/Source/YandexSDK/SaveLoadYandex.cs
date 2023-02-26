using Agava.YandexGames;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SaveLoadGame))]
public class SaveLoadYandex : MonoBehaviour
{
    private SaveLoadGame _game;

    private void Awake()
    {
        _game = GetComponent<SaveLoadGame>();
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        _game.Saved += SetData;
        yield break;
    }

    public void GetData()
    {
        Action<string> getData = new Action<string>(LoadData);
        PlayerAccount.GetPlayerData(getData);
    }

    private void SetData()
    {
        string saves = _game.GetJson();
        PlayerAccount.SetPlayerData(saves);
    }

    private void LoadData(string data)
    {
        _game.JsonLoad(data);
    }
}
