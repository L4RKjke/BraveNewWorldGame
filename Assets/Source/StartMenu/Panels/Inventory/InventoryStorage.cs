using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryStorage : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private GameObject _button;

    private List<ItemInventory> _cells = new List<ItemInventory>();

    private InventoryUI _inventoryUI;
    private TMP_Text _price;
    private TMP_Text _count;
    private int _bagSize = 21;
    private int _priceBagUp = 200;
    private readonly int _bagUpCount = 7;
    private readonly int _priceIncrease = 200;

    public int InventorySize => _cells.Count;
    public int BagSize => _bagSize;

    private void Start()
    {
        _price = _button.transform.GetChild(0).GetComponent<TMP_Text>();
        _count = _button.transform.GetChild(1).GetComponent<TMP_Text>();
        _inventoryUI = GetComponent<InventoryUI>();
        _count.text = "+" + _bagUpCount;
        UpdateText();
    }

    public ItemInventory GetItem(int id)
    {
        return _cells[id];
    }

    public void TryToUpgradeBag()
    {
        if(_priceBagUp <= _wallet.Crystals)
        {
            _wallet.ChangeCrystals(-_priceBagUp);
            _priceBagUp += _priceIncrease;
            UpgradeBag();
            _inventoryUI.UpdateInventoryUI();
            UpdateText();
        }
        else
        {
            string notMone� = "NotMoney";
            _button.GetComponent<Animator>().SetTrigger(notMone�);
        }
    }

    public void AddItem(int id, Item item)
    {
        _cells[id].UpdateInformation(item.Id, item.Image, item.Type);
    }

    public void AddSlot(ItemInventory slot)
    {
        _cells.Add(slot);
    }

    public void TrySortingInventory(int startId, PlayerItemStorage itemStorage)
    {
        bool needSorting = true;
        int lastId = _cells[0].Id;
        int countSortingBreak = 0;

        for (int i = 0; i < _cells.Count; i++)
        {

            if (_cells[i].Id == 0 && lastId != _cells[i].Id)
            {
                countSortingBreak++;

                if (countSortingBreak == 2)
                {
                    needSorting = false;
                    break;
                }
            }

            lastId = _cells[i].Id;
        }

        if (needSorting)
            SortingInventory(startId, itemStorage);
    }

    private void SortingInventory(int startId, PlayerItemStorage itemStorage)
    {
        for (int i = startId; i < InventorySize; i++)
        {
            if (i < InventorySize - 1)
            {
                AddItem(i, itemStorage.GetItem(GetItem(i + 1).Id));
            }
            else
            {
                AddItem(i, itemStorage.GetItem(0));
            }
        }
    }

    private void UpgradeBag()
    {
        _bagSize += _bagUpCount;
    }

    private void UpdateText()
    {
        _price.text = " = " + _priceBagUp + "/" + _wallet.Crystals;
    }
}
