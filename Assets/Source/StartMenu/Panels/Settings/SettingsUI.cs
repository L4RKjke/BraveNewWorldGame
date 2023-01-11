using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioSource _backGroundTrack;

    string _volume = "Volume";
    int _valueDecrease = 20;
    string _start = "Start";

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volume);
        _audioMixer.SetFloat(_volume, Mathf.Log10(0.0001f) * _valueDecrease);
        SoundFading(_start);
    }

    public void SoundFading(string choice = "End")
    {
        if (choice == _start)
        {
            StartCoroutine(CoroutineSoundIncrease(PlayerPrefs.GetFloat(_volume)));
        }
        else
        {
            StartCoroutine(CoroutineSoundDecrease(PlayerPrefs.GetFloat(_volume)));
        }
    }

    public void SetVolume(float value)
    {
        Debug.Log(value);
        _audioMixer.SetFloat(_volume, Mathf.Log10(value) * _valueDecrease);
        PlayerPrefs.SetFloat(_volume, value);
    }

    public void SetQuality(int qualitiIndex)
    {
        QualitySettings.SetQualityLevel(qualitiIndex);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void EndSounds(AudioSource track)
    {
        track.Play();
        StartCoroutine(SoundOff(_backGroundTrack));
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

        Debug.Log("End");
    }

    private IEnumerator CoroutineSoundDecrease(float value)
    {
        float expiredTime = 1f;

        while (expiredTime > 0)
        {
            Debug.Log(value);
            expiredTime -= Time.deltaTime;
            _audioMixer.SetFloat(_volume, Mathf.Log10(value * expiredTime) * _valueDecrease);
            yield return null;
        }

        Debug.Log("End");
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
}