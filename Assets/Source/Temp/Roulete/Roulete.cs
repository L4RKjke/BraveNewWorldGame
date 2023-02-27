using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Roulete : MonoBehaviour
{
    [SerializeField] private Button _spinButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private SpinTimer _spinTimer;
    [SerializeField] private GameObject _wheel;
    [SerializeField] private PlayerWallet _wallet;

    private readonly List<int> _prizes = new List<int> { 50, 5000, 300, 100, 2000, 500, 1000, 250 };
    private readonly int _maxAngel = 360;
    private readonly float _updateDelay = 0.01f;
    private readonly float _spinSpeed = 7;
    private readonly int _prizeSections = 8;
    private readonly string _routineName = "Spin";

    public UnityAction Spined;

    private void OnEnable()
    {
        _spinTimer.TimeOver += ActivateButton;
    }

    private void OnDisable()
    {
        _spinTimer.TimeOver -= ActivateButton;
        StopCoroutine(_routineName);
    }

    public void OnSpinButtonClick()
    {
        Action videoShowed = new Action(StartSpin);
        VideoAd.Show(null, null, videoShowed);
    }

    private void StartSpin()
    {
        ResetRoulete();
        StopCoroutine(_routineName);
        StartCoroutine(_routineName);
        _spinButton.interactable = false;
        _spinTimer.StartTimer();
    }

    private void ActivateButton()
    {
        _spinButton.interactable = true;
    }

    private void RotateRoulete(float angel)
    {
        _wheel.transform.rotation = Quaternion.Euler(0, 0, angel);
    }

    private void ResetRoulete()
    {
        _wheel.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private IEnumerator Spin()
    {
        float currentAngel = 0;
        float spitSpeed = _spinSpeed;
        float speedSpread = UnityEngine.Random.Range(0.01f, 0.04f);

        while (spitSpeed > 0)
        {
            yield return new WaitForSeconds(_updateDelay);

            spitSpeed -= speedSpread;
            currentAngel += spitSpeed;
            RotateRoulete(currentAngel);

            if (spitSpeed <= 0)
            {
                spitSpeed = 0;
                GetCurrentPrise(currentAngel);
            }
        }
    }

    private void GetCurrentPrise(float angel)
    {
        float _angelCorection = 22.5f;
        int sectionId = (Mathf.FloorToInt((angel) % _maxAngel + _angelCorection) / (_maxAngel / _prizeSections));

        switch (sectionId)
        {
            case 1:
                _wallet.ChangeGold(_prizes[0]);
                Debug.Log(_prizes[0]);
                break;
            case 2:
                _wallet.ChangeGold(_prizes[1]);
                Debug.Log(_prizes[1]);
                break;
            case 3:
                _wallet.ChangeGold(_prizes[2]);
                Debug.Log(_prizes[2]);
                break;
            case 4:
                _wallet.ChangeCrystals(_prizes[3]);
                Debug.Log(_prizes[3]);
                break;
            case 5:
                _wallet.ChangeGold(_prizes[4]);
                Debug.Log(_prizes[4]);
                break;
            case 6:
                _wallet.ChangeGold(_prizes[5]);
                Debug.Log(_prizes[5]);
                break;
            case 7:
                _wallet.ChangeGold(_prizes[6]);
                Debug.Log(_prizes[6]);
                break;
            case 8:
                _wallet.ChangeCrystals(_prizes[7]);
                Debug.Log(_prizes[7]);
                break;
        }

        Spined?.Invoke();
    }
}