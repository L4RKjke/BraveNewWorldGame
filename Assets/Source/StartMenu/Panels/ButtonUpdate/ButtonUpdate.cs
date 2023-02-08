using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonUpdate : MonoBehaviour
{
    private int _priceUpdate;
    private PlayerWallet _wallet;

    public Button Button => this.GetComponent<Button>();

    private void Start()
    {
        TMP_Text text = this.GetComponentInChildren<TMP_Text>();
        text.text = _priceUpdate.ToString();
    }

    private void OnEnable()
    {
        if (_wallet.Gold >= _priceUpdate)
        {
            TMP_Text text = this.GetComponentInChildren<TMP_Text>();
            text.color = Color.white;
        }
    }

    public void Init(int price, PlayerWallet wallet)
    {
        _priceUpdate = price;
        _wallet = wallet;
        enabled = true;
    }

    public bool CheckCanUpdate()
    {
        bool canUpdate = false;
        TMP_Text text = this.GetComponentInChildren<TMP_Text>();

        if (_wallet.Gold >= _priceUpdate)
        {
            text.color = Color.white;
            canUpdate = true;
        }
        else
        {
            string noMoney = "NoMoney";
            text.color = Color.red;
            this.GetComponent<Animator>().SetTrigger(noMoney);
        }

        return canUpdate;
    }
}
