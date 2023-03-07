using Agava.YandexGames;
using System;
using UnityEngine;

public class SaveComparison : MonoBehaviour
{
    [SerializeField] private ChangeSaves _changeSaves;

    private Action<JsonDataSaves> _succes;
    private Action _unSucces;
    private JsonDataSaves _local = null;

    public void Compare()
    {
        if(_local != null)
        {
            Action<JsonDataSaves> isSucces = new Action<JsonDataSaves>(NeedChange);
            Action unSucces = new Action(NoNeedChange);
            TryGetData(isSucces, unSucces);
        }
    }

    public void TryGetData(Action<JsonDataSaves> succes, Action unSucces = null)
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return;
#endif
        _succes = succes;
        _unSucces = unSucces;
        Action<string> getData = new Action<string>(GetData);
        Action<string> getDataUnSucces = new Action<string>(UnSuccesGetData);
        PlayerAccount.GetPlayerData(getData, getDataUnSucces);
    }

    public void SetLocal(JsonDataSaves local)
    {
        _local = local;
    }

    private void NoNeedChange()
    {
        string saves = JsonUtility.ToJson(_local);
        PlayerAccount.SetPlayerData(saves);
    }

    private void NeedChange(JsonDataSaves data)
    {
        if (_local != data)
        {
            _changeSaves.gameObject.SetActive(true);
            _changeSaves.Init(_local);
        }
    }

    private void UnSuccesGetData(string data)
    {
        if (_unSucces != null)
        _unSucces.Invoke();
    }

    private void GetData(string data)
    {
        JsonDataSaves jsonDataSaves = JsonUtility.FromJson<JsonDataSaves>(data);
        _succes.Invoke(jsonDataSaves);
    }
}
