using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TelepotrSounds : Sounds
{
    [SerializeField] private AudioMixer _audioMixer;

    string _volume = "Effects";
    private int _valueSound = 0;

    public void GetTpSound()
    {
        AudioSource.PlayOneShot(GetClip(0));
    }

    public void GetHoleSound()
    {
        EffectsIncrease();
        AudioSource.PlayOneShot(GetClip(1));
    }

    private void EffectsIncrease()
    {
        int valueIncrease = 10;
        _audioMixer.SetFloat(_volume, _valueSound);
        _valueSound += valueIncrease;
    }

/*    private IEnumerator CoroutineSoundIncrease()
    {
        float expiredTime = 0.3f;

        while (expiredTime < 1)
        {
            expiredTime += Time.deltaTime;
            _audioMixer.SetFloat(_volume, Mathf.Log10(10 * expiredTime) * _valueDecrease);
            yield return null;
        }
    }*/
}
