using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveComparison : MonoBehaviour
{
    [SerializeField] private ChangeSaves _changeSaves;

    private Action<JsonDataSaves> _succes;
    private Action _unSucces;

    private string _data = "";
    private JsonDataSaves _local = null;

    public void Compare()
    {
        if(_local != null)
        {
            Debug.Log("���������");
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
        Debug.Log("������� ����� �������");
        PlayerAccount.GetPlayerData(getData, getDataUnSucces);
    }

    public void SetLocal(JsonDataSaves local)
    {
        _local = local;
    }

    private void NoNeedChange()
    {
        Debug.Log("�� ������� ������");
        string saves = JsonUtility.ToJson(_local);
        PlayerAccount.SetPlayerData(saves);
    }

    private void NeedChange(JsonDataSaves data)
    {
        Debug.Log("�������� �����");

        if (_local != data)
        {
            _changeSaves.gameObject.SetActive(true);
            _changeSaves.Init(_local);
        }
        else
        {
            Debug.Log("��������� ��� �� �����");
        }
    }

    private void UnSuccesGetData(string data)
    {
        Debug.Log("������� �����");
        _unSucces.Invoke();
    }

    private void GetData(string data)
    {
        Debug.Log("����� �����");
        JsonDataSaves jsonDataSaves = JsonUtility.FromJson<JsonDataSaves>(data);
        _succes.Invoke(jsonDataSaves);
    }
}
