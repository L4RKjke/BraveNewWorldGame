using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Agava.YandexGames;
using System.Collections;

public class RouletePanel : MonoBehaviour
{
    [SerializeField] private GameObject _rouletePanel;
    [SerializeField] private GameObject _menuTimer;
    [SerializeField] private SpinTimer _spinTimer;
    [SerializeField] private Button _spinX2Button;
    [SerializeField] private Roulete _roulete;
    [SerializeField] private Button _spinButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private TextMeshProUGUI _menuText;
    [SerializeField] private TextMeshProUGUI _RouletPanelTXT;
    [SerializeField] private int _spinDelay;

    private readonly string _sound = "Sound";

    private void OnEnable()
    {
        ResetRoulete();

        _roulete.Spined += OnSpined;
        _spinTimer.TimeUpdated += UpdateTime;
        _spinTimer.TimeOver += ActivateSpinButton;
    }

    private void OnDisable()
    {
        _roulete.Spined -= OnSpined;
        _spinTimer.TimeUpdated -= UpdateTime;
        _spinTimer.TimeOver -= ActivateSpinButton;
    }

    public void OnSpinButtonClick(int multi = 1)
    {
        _roulete.StartSpin(multi);
        _closeButton.interactable = false;
        _spinButton.interactable = false;
        _spinX2Button.interactable = false;
    }

    public void OnRouleteButtonClick()
    {
        _rouletePanel.SetActive(true);
        _menuTimer.SetActive(false);
    }

    public void OnRouleteClosePanel()
    {
        _menuTimer.SetActive(true);
        _rouletePanel.SetActive(false);
    }

    public void OnSpinX2ButtonClick()
    {
        Action videoShowed = new Action(AdShowed);
        VideoAd.Show(null, null, videoShowed, errorLog => OnAdError(errorLog));

        if (PlayerPrefs.GetInt(_sound) == 0)
        {
            AudioListener.pause = true;
        }
    }

    private void AdShowed()
    {
        int multi = 2;
        SoundOn();
        OnSpinButtonClick(multi);
    }

    private void OnSpined()
    {
        ResetRoulete();
        _closeButton.interactable = true;
    }

    private void ActivateSpinButton()
    {
        _spinButton.interactable = true;
        _spinX2Button.interactable = true;
    }

    private void SoundOn()
    {
        if (PlayerPrefs.GetInt(_sound) == 0)
        {
            AudioListener.pause = false;
        }
    }

    private void UpdateTime(string time)
    {
        _menuText.text = time;
        _RouletPanelTXT.text = time;
    }

    private void OnAdError(string error)
    {
        SoundOn();
    }

    private void ResetRoulete()
    {
        _spinTimer.ResetTimer();
        _spinTimer.ResetMinutes();
        _spinTimer.SetMinutes(_spinDelay);
        _spinTimer.StartTimer();
    }
}
