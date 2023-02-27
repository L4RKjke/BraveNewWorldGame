using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveComparison : MonoBehaviour
{
    [SerializeField] private ChangeSaves _changeSaves;

    private string _data = "";
    private JsonDataSaves _local;

    public void Compare()
    {
        JsonDataSaves cloud = TryGetData();

        if(_local == null)
        {
        }
        else if(cloud == null)
        {
            string saves = JsonUtility.ToJson(_local);
            PlayerAccount.SetPlayerData(saves);
        }
        else if(_local != cloud)
        {
            _changeSaves.gameObject.SetActive(true);
            _changeSaves.Init(_local);
        }
    }

    public JsonDataSaves TryGetData()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return null;
#endif
        Action<string> getData = new Action<string>(GetData);
        PlayerAccount.GetPlayerData(getData);
        Debug.Log(_data);
        JsonDataSaves jsonDataSaves = JsonUtility.FromJson<JsonDataSaves>(_data);
        return jsonDataSaves;
    }

    public void SetLocal(JsonDataSaves local)
    {
        _local = local;
    }

    private void GetData(string data)
    {
        _data = data;
    }
}
