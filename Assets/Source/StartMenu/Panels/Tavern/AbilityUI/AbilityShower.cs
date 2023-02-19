using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityShower : TextShower
{
    [SerializeField] private TMP_Text _description;

    public void Init(string description)
    {
        _description.text = description;
    }
}
