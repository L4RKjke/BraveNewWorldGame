using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterSaver : MonoBehaviour
{
    private void Start()
    {
        WalletData wallet = BinarySavingSystem.LoadWallet();
        Debug.Log(wallet.Gold);
    }
}
