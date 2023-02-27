using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TelepotrSounds : Sounds
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private GameObject _character;

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

    public void OffCharacter()
    {
        _character.SetActive(false);
    }

    private void EffectsIncrease()
    {
        int valueIncrease = 10;
        _audioMixer.SetFloat(_volume, _valueSound);
        _valueSound += valueIncrease;
    }
}
