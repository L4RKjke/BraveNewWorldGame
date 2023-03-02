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
    [SerializeField] private SaveComparison _compare;
    [SerializeField] private GameObject _authorize;
    [SerializeField] private GameObject _leaderBoard;

    private Coroutine _startScene;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPlayStart()
    {
        StartCoroutine(StartScene());
    }

    public void ButtonOff()
    {
        _teleport.SetActive(true);
    }

    private IEnumerator StartScene()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        UnSuccesSaves();
        yield break;
#endif

        if (_startScene == null)
        {
            Debug.Log("Start");
            Action<JsonDataSaves> isSucces = new Action<JsonDataSaves>(SuccesSaves);
            Action unSucces = new Action(UnSuccesSaves);
            _compare.TryGetData(isSucces, unSucces);
        }
        yield break;
    }

    private void SuccesSaves(JsonDataSaves json)
    {
        if (json.CharactersData.Length > 0)
            _startScene = StartCoroutine(StartScene(1));
        else
            UnSuccesSaves();
    }

    private void UnSuccesSaves()
    {
        bool isCreated = BinarySavingSystem.CheckSaves();

        if (isCreated == true)
        {
            _startScene = StartCoroutine(StartScene(1));
        }
        else
        {
            _startScene = StartCoroutine(StartScene(2));
        }
    }

    private IEnumerator StartScene(int scene)
    {
        string off = "Off";
        _buttons.GetComponent<Animator>().SetTrigger(off);
        _animator.SetTrigger(off);

        if(_authorize.activeSelf == true)
            _authorize.GetComponent<Animator>().SetTrigger(off);
        else
            _leaderBoard.GetComponent<Animator>().SetTrigger(off);

        float waiting = 3f;
        yield return new WaitForSeconds(waiting);;
        _blackScreen.GetComponent<Animator>().SetTrigger(off);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
