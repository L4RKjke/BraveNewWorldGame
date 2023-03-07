using System.Collections.Generic;
using UnityEngine;

public class EquippedItemsSaveLoad : MonoBehaviour, BinarrySaves
{
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private PlayerItemStorage _itemStorage;

    public void Load(List<EquipItemData> items)
    {
        CharacterItems characterItems;
        Item item;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].CountItems > 0)
            {
                characterItems = _charactersStorage.GetCharacter(i).GetComponent<CharacterItems>();

                for(int j = 0; j < items[i].CountItems; j++)
                {
                    item = _itemStorage.GetItem(items[i].ItemsID[j]);
                    characterItems.ChangeItem(item.Type, true, item, items[i].InHand[j]); ;
                }
            }
        }
    }

    public void Save()
    {
        BinarySavingSystem.SaveEquippedItems(_charactersStorage);
    }

    public EquippedItemsData GetData()
    {
        EquippedItemsData equppedItemData = new EquippedItemsData(_charactersStorage);
        return equppedItemData;
    }
}
