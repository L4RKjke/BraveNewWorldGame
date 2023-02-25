using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private SaveLoadGame _save;

    public void OnEnable()
    {
        _save.Saved += SetSaves;
    }

    public void OnDisable()
    {
        _save.Saved -= SetSaves;
    }

    private void SetSaves()
    {
        BinarySavingSystem.LoadWallet();
        BinarySavingSystem.LoadCharacter();
        BinarySavingSystem.LoadItems();
        BinarySavingSystem.LoadItemInventory();
        BinarySavingSystem.LoadEquippedItems();
        BinarySavingSystem.LoadShop();
        BinarySavingSystem.LoadTavern();
    }
}
