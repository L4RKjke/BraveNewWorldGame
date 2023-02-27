using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject _blackScreen;
    [SerializeField] private GameObject _teleport;
    [SerializeField] private GameObject _buttons;

    private Coroutine _startScene;
    private Animator _animator;
    private string _data = "";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPlayStart()
    {
        bool isCreated = BinarySavingSystem.CheckSaves();

        JsonDataSaves jsonDataSaves = TryGetData();

        if ((_startScene == null && isCreated == true) || (_startScene == null && jsonDataSaves != null))
        {
            _startScene = StartCoroutine(StartScene(1));
        }
        else if(_startScene == null)
        {
            _startScene = StartCoroutine(StartScene(2));
        }
    }

    public void ButtonOff()
    {
        _teleport.SetActive(true);
    }

    private IEnumerator StartScene(int scene)
    {
        string off = "Off";
        _buttons.GetComponent<Animator>().SetTrigger(off);
        _animator.SetTrigger(off);
        float waiting = 3f;
        yield return new WaitForSeconds(waiting);;
        _blackScreen.GetComponent<Animator>().SetTrigger(off);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    private JsonDataSaves TryGetData()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        return null;
#endif
        Action<string> getData = new Action<string>(GetData);
        PlayerAccount.GetPlayerData(getData);
        JsonDataSaves jsonDataSaves = JsonUtility.FromJson<JsonDataSaves>(_data);
        return jsonDataSaves;
    }

    private void GetData(string data)
    {
        _data = data;
    }
}
