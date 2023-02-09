using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    [SerializeField] private Sprite _head;
    [SerializeField] private string _name;

    public Sprite Sprite => _head;
    public string Name => _name;
}
