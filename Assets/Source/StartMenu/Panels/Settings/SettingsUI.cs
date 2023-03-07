using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private TMP_Dropdown _dropdownQuality;
    [SerializeField] private GameObject _blackScreen;
    [SerializeField] private Toggle _toggle;

    private string _volume = "Volume";
    private int _valueDecrease = 20;
    private string _start = "Start";

    private void Awake()
    {
        SetPlayerPrefSettings();
    }

    private void Start()
    {
        _dropdownQuality.options[0].text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Quality/Low");
        _dropdownQuality.options[1].text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Quality/Medium");
        _dropdownQuality.options[2].text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Quality/High");
        _dropdownQuality.options[3].text = Lean.Localization.LeanLocalization.GetTranslationText("Common/Quality/Ultra");
    }

    public void SoundFading(string choice = "End")
    {
        if (choice == _start)
        {
            StartCoroutine(CoroutineSoundIncrease(PlayerPrefsDataBase.GetVolume()));
        }
        else
        {
            StartCoroutine(CoroutineSoundDecrease(PlayerPrefsDataBase.GetVolume()));
        }
    }

    public void SetVolume(float value)
    {
        _audioMixer.SetFloat(_volume, Mathf.Log10(value) * _valueDecrease);
        PlayerPrefsDataBase.SetVolume(value);
    }

    public void SetQuality(int qualitiIndex)
    {
        QualitySettings.SetQualityLevel(qualitiIndex);
        PlayerPrefsDataBase.SetQuality(qualitiIndex);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;

        if (AudioListener.pause == true)
            PlayerPrefsDataBase.SetSound(1);
        else
            PlayerPrefsDataBase.SetSound(0);
    }

    public void ReloadSceneLanguage()
    {
        StartCoroutine(RestartScene());
    }

    private void SetPlayerPrefSettings()
    {
        if (PlayerPrefsDataBase.GetVolume() == 0)
        {
            float startVolume = 0.5f;
            PlayerPrefsDataBase.SetVolume(startVolume);
        }

        _sliderSound.value = PlayerPrefsDataBase.GetVolume();
        _audioMixer.SetFloat(_volume, Mathf.Log10(0.0001f) * _valueDecrease);
        SoundFading(_start);
        SetQuality(PlayerPrefsDataBase.GetQuality());
        _dropdownQuality.value = PlayerPrefsDataBase.GetQuality();

        if (PlayerPrefsDataBase.GetSound() == 1)
        {
            _toggle.isOn = false;
            AudioListener.pause = true;
        }
    }

    private IEnumerator CoroutineSoundIncrease(float value)
    {
        float expiredTime = 0f;

        while (expiredTime < 1)
        {
            expiredTime += Time.deltaTime;
            _audioMixer.SetFloat(_volume, Mathf.Log10(value * expiredTime) * _valueDecrease);
            yield return null;
        }
    }

    private IEnumerator CoroutineSoundDecrease(float value)
    {
        float expiredTime = 1f;

        while (expiredTime > 0)
        {
            expiredTime -= Time.deltaTime;
            _audioMixer.SetFloat(_volume, Mathf.Log10(value * expiredTime) * _valueDecrease);
            yield return null;
        }
    }

    private IEnumerator SoundOff(AudioSource track)
    {
        float expiredTime = 1f;

        while (expiredTime > 0)
        {
            expiredTime -= Time.deltaTime;
            track.volume = Mathf.MoveTowards(track.volume, 0, 1 * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator RestartScene()
    {
        string off = "Off";
        float waiting = 2f;
        _blackScreen.GetComponent<Animator>().SetTrigger(off);
        yield return new WaitForSeconds(waiting); ;
        SceneManager.LoadScene(1);
    }
}