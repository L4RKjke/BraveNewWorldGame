using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WalletSaveLoad))]
[RequireComponent(typeof(CharactersSaveLoad))]
[RequireComponent(typeof(ItemsSaveLoad))]
public class SaveLoadGame : MonoBehaviour , BinarrySaveLoad
{
    private WalletSaveLoad _wallet;
    private CharactersSaveLoad _charactersSaveLoad;
    private ItemsSaveLoad _itemsSaveLoad;

    private void Awake()
    {
        _wallet = GetComponent<WalletSaveLoad>();
        _charactersSaveLoad = GetComponent<CharactersSaveLoad>();
        _itemsSaveLoad = GetComponent<ItemsSaveLoad>();

        BinarySavingSystem.CreateDirectoryInfo();
    }

    public void Load()
    {
        _wallet.Load();
        _charactersSaveLoad.Load();
        _itemsSaveLoad.Load();
    }

    public void Save()
    {
        _wallet.Save();
        _charactersSaveLoad.Save();
        _itemsSaveLoad.Save();
    }
}
