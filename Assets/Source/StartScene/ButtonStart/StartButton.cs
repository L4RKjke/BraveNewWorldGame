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

    private Coroutine _startScene;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPlayStart()
    {
        bool isCreated = BinarySavingSystem.CheckSaves();

        JsonDataSaves jsonDataSaves = _compare.TryGetData();

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

        if(_authorize.activeSelf == true)
            _authorize.GetComponent<Animator>().SetTrigger(off);

        float waiting = 3f;
        yield return new WaitForSeconds(waiting);;
        _blackScreen.GetComponent<Animator>().SetTrigger(off);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
