using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Roulete : MonoBehaviour
{
    [SerializeField] private GameObject _wheel;
    [SerializeField] private PlayerWallet _wallet;

    private readonly List<int> _prizes = new List<int> { 250, 50, 5000, 300, 100, 2000, 500, 1000 };
    private readonly int _maxAngel = 360;
    private readonly float _updateDelay = 0.01f;
    private readonly float _spinSpeed = 7;
    private readonly int _prizeSections = 8;
    private Coroutine _spinRoutine;

    public UnityAction Spined;
    public UnityAction SpinStarted;

    private void OnDisable()
    {
        if(_spinRoutine != null)
        StopCoroutine(_spinRoutine);
    }

    public void StartSpin(int multi)
    {
        ResetRoulete();

        if (_spinRoutine != null)
            StopCoroutine(_spinRoutine);

        _spinRoutine = StartCoroutine(Spin(multi));
        SpinStarted?.Invoke();
    }

    private void RotateRoulete(float angel)
    {
        _wheel.transform.rotation = Quaternion.Euler(0, 0, angel);
    }

    private void ResetRoulete()
    {
        _wheel.transform.rotation = Quaternion.identity;
    }

    private IEnumerator Spin(int multi)
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
                GetCurrentPrise(currentAngel, multi);
                break;
            }
        }
    }

    private void GetCurrentPrise(float angel, int multi)
    {
        float correctionAngel = _maxAngel / _prizeSections / 2;
        int sectionId = Mathf.FloorToInt((angel % _maxAngel + correctionAngel) / (_maxAngel / _prizeSections));

        switch (sectionId)
        {
            case 0:
                _wallet.ChangeCrystals(_prizes[0] * multi);
                break;
            case 1:
                _wallet.ChangeGold(_prizes[1] * multi);
                break;
            case 2:
                _wallet.ChangeGold(_prizes[2] * multi);
                break;
            case 3:
                _wallet.ChangeGold(_prizes[3] * multi);
                break;
            case 4:
                _wallet.ChangeCrystals(_prizes[4] * multi);
                break;
            case 5:
                _wallet.ChangeGold(_prizes[5] * multi);
                break;
            case 6:
                _wallet.ChangeGold(_prizes[6] * multi);
                break;
            case 7:
                _wallet.ChangeGold(_prizes[7] * multi);
                break;
        }

        Spined?.Invoke();
    }
}