using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(RouletteReward))]

public class Roulete : MonoBehaviour
{
    [SerializeField] private GameObject _wheel;
    [SerializeField] private List<RoulettePrize> _prizes;
    [SerializeField] private GameObject _container;

    private RouletteReward _rouletteReward;
    private readonly int _maxAngel = 360;
    private readonly float _updateDelay = 0.01f;
    private readonly float _spinSpeed = 7;
    private readonly int _prizeSections = 8;
    private Coroutine _spinRoutine;

    public UnityAction Spined;
    public UnityAction SpinStarted;

    private void Awake()
    {
        _rouletteReward = GetComponent<RouletteReward>();
    }

    private void OnDisable()
    {
        if(_spinRoutine != null)
        StopCoroutine(_spinRoutine);
    }

    private void Start()
    {
        for (int i = 0; i < _container.transform.childCount; i++)
        {
            _container.transform.GetChild(i).GetComponent<Image>().sprite = _prizes[i].Sprite;
            _container.transform.GetChild(i).transform.GetChild(0).GetComponent<TMP_Text>().text = _prizes[i].PrizeCount.ToString();
        }
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

        _rouletteReward.SetReward(_prizes[sectionId].PrizeCount * multi, _prizes[sectionId].Sprite, _prizes[sectionId].Type);

        Spined?.Invoke();
    }
}

[System.Serializable]
public class RoulettePrize
{
    [SerializeField] private int _prizeCount;
    [SerializeField] private Sprite _image;
    [SerializeField] private ValueType _type;

    public int PrizeCount => _prizeCount;

    public Sprite Sprite => _image;

    public ValueType Type => _type;
}

public enum ValueType
{
    Gold,
    Crystal
}