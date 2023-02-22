using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Sounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clipList;

    protected AudioSource AudioSource;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    protected AudioClip GetClip(int id)
    {
        return _clipList[id];
    }
}
