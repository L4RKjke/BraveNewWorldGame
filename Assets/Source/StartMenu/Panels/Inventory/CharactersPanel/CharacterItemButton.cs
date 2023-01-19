using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemButton : MonoBehaviour
{
    [SerializeField] private string _requireType;

    public string RequireType => _requireType;
}
