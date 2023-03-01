using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Agava.YandexGames;

public class RouletePanel : MonoBehaviour
{
    [SerializeField] private GameObject _rouletePanel;
    [SerializeField] private GameObject _menuTimer;
    [SerializeField] private SpinTimer _spinTimer;
    [SerializeField] private Button _skipButton;
    [SerializeField] private Roulete _roulete;
    [SerializeField] private Button _spinButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private TextMeshProUGUI _menuText;
    [SerializeField] private TextMeshProUGUI _RouletPanelTXT;

    private readonly string _sound = "Sound";

    private void OnEnable()
    {
        _spinTimer.ResetTimer();
        _spinTimer.ResetMinutes();
        _spinTimer.SetMinutes(5);
        _spinTimer.StartTimer();

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

    public void OnSpinButtonClick()
    {
        _roulete.StartSpin();
        _spinButton.interactable = false;
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

    public void OnSkipButtonClick()
    {
        Action videoShowed = new Action(AdShowed);
        VideoAd.Show(null, null, videoShowed, errorLog => OnAdError(errorLog));
        _skipButton.interactable = false;

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.pause = true;
        }
    }

    private void AdShowed()
    {
        SoundOff();
        SkipTime();
    }

    private void OnSpined()
    {
        _skipButton.interactable = true;
        _spinTimer.ResetTimer();
        _spinTimer.ResetMinutes();
        _spinTimer.SetMinutes(5);
        _spinTimer.StartTimer();
    }

    private void ActivateSpinButton()
    {
        _spinButton.interactable = true;
    }

    private void SkipTime()
    {
        _spinTimer.ResetTimer();
        _spinTimer.ResetMinutes();
        _spinTimer.SetMinutes(2);
        _spinTimer.StartTimer();
    }

    private void SoundOff()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
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
        AdShowed();
    }
}
