using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class StartSoundSet : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Toggle _toggle;

    private string _volume = "Volume";
    private int _valueDecrease = 20;

    private void Start()
    {
        if (PlayerPrefsDataBase.GetVolume() == 0)
        {
            float startVolume = 0.5f;
            PlayerPrefsDataBase.SetVolume(startVolume);
        }

        _audioMixer.SetFloat(_volume, Mathf.Log10(PlayerPrefsDataBase.GetVolume()) * _valueDecrease);

        if (PlayerPrefsDataBase.GetSound() == 1)
        {
            _toggle.isOn = false;
            AudioListener.pause = true;
        }
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;

        if (AudioListener.pause == true)
            PlayerPrefsDataBase.SetSound(1);
        else
            PlayerPrefsDataBase.SetSound(0);
    }
}
