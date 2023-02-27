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

    private readonly List<int> _prizes = new List<int> { 100, 200, 300, 400, 500, 600, 700, 800 };
    private readonly int _maxAngel = 360;
    private readonly float _updateDelay = 0.01f;
    private readonly float _spinSpeed = 7;
    private readonly int _prizeSections = 8;
    private readonly string _routineName = "Spin";

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
        float speedSpread = Random.Range(0.01f, 0.04f);

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
                Debug.Log(1);
                break;
            case 2:
                Debug.Log(2);
                break;
            case 3:
                Debug.Log(3);
                break;
            case 4:
                Debug.Log(4);
                break;
            case 5:
                Debug.Log(5);
                break;
            case 6:
                Debug.Log(6);
                break;
            case 7:
                Debug.Log(7);
                break;
            case 8:
                Debug.Log(8);
                break;
        }
    }
}