using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RouletteReward : MonoBehaviour
{
    [SerializeField] private GameObject _reward;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private List<Color> _rewardColor;

    public UnityAction RewardAdded;

    public void SetReward(int count, Sprite image, ValueType type)
    {
        _image.sprite = image;
        _text.text = count.ToString();

        if (type == ValueType.Gold)
            _text.color = _rewardColor[0];
        else
            _text.color = _rewardColor[1];

        _button.onClick.AddListener(delegate { AddReward(count, type); });
        _reward.SetActive(true);
    }

    private void AddReward(int count, ValueType type)
    {
        if(type == ValueType.Gold)
        {
            _wallet.ChangeGold(count);
        }
        else
        {
            _wallet.ChangeCrystals(count);
        }

        _button.onClick.RemoveAllListeners();
        RewardAdded?.Invoke();
        _reward.SetActive(false);
    }
}
