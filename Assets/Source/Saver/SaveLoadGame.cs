using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WalletSaveLoad))]
[RequireComponent(typeof(CharactersSaveLoad))]
[RequireComponent(typeof(ItemsSaveLoad))]
[RequireComponent(typeof(ItemInventorySaveLoad))]
[RequireComponent(typeof(EquippedItemsSaveLoad))]
[RequireComponent(typeof(ShopSaveLoad))]
[RequireComponent(typeof(TavernSaveLoad))]
public class SaveLoadGame : MonoBehaviour , BinarrySaveLoad
{
    [SerializeField] private FinalPanels _finalPanels;
    [SerializeField] private DoublePanel _panel;

    private void OnEnable()
    {
        if (_finalPanels != null)
        {
            _finalPanels.BattleEnd += SaveDelay;
            _panel.PanelClosed += SaveDelay;
        }
    }

    private void OnDisable()
    {
        if (_finalPanels != null)
        {
            _finalPanels.BattleEnd -= SaveDelay;
            _panel.PanelClosed -= SaveDelay;
        }
    }

    private WalletSaveLoad _wallet;
    private CharactersSaveLoad _charactersSaveLoad;
    private ItemsSaveLoad _itemsSaveLoad;
    private ItemInventorySaveLoad _itemInventorySaveLoad;
    private EquippedItemsSaveLoad _equippedItemsSaveLoad;
    private ShopSaveLoad _shopSaveLoad;
    private TavernSaveLoad _tavernSaveLoad;

    private void Awake()
    {
        _wallet = GetComponent<WalletSaveLoad>();
        _charactersSaveLoad = GetComponent<CharactersSaveLoad>();
        _itemsSaveLoad = GetComponent<ItemsSaveLoad>();
        _itemInventorySaveLoad = GetComponent<ItemInventorySaveLoad>();
        _equippedItemsSaveLoad = GetComponent<EquippedItemsSaveLoad>();
        _shopSaveLoad = GetComponent<ShopSaveLoad>();
        _tavernSaveLoad = GetComponent<TavernSaveLoad>();

        BinarySavingSystem.CreateDirectoryInfo();
    }

    public void Load()
    {
        _wallet.Load();
        _charactersSaveLoad.Load();
        _itemsSaveLoad.Load();
        _itemInventorySaveLoad.Load();
        _equippedItemsSaveLoad.Load();
        _shopSaveLoad.Load();
        _tavernSaveLoad.Load();
    }

    public void Save()
    {
        _wallet.Save();
        _charactersSaveLoad.Save();
        _itemsSaveLoad.Save();
        _itemInventorySaveLoad.Save();
        _equippedItemsSaveLoad.Save();
        _shopSaveLoad.Save();
        _tavernSaveLoad.Save();
    }

    private void SaveDelay()
    {
        StartCoroutine(CoroutineSaveDelay());
    }

    private IEnumerator CoroutineSaveDelay()
    {
        float delay = 1;
        yield return new WaitForSeconds(delay);
        Save();
    }
}
