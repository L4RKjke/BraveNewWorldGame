using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _crystalsText;

    private int _gold = 500;
    private int _crystals = 777;

    public int Gold => _gold;
    public int Crystals => _crystals;

    private void Start()
    {
        _goldText.text = _gold.ToString();
        _crystalsText.text = _crystals.ToString();
    }

    public void ChangeGold(int count)
    {
        _gold += count;
        _goldText.text = _gold.ToString();
    }

    public void ChangeCrystals(int count)
    {
        _crystals += count;
        _crystalsText.text = _crystals.ToString();
    }
}
