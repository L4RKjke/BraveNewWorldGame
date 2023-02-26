using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItemsSaveLoad : MonoBehaviour, BinarrySaves
{
    [SerializeField] private CharactersStorage _charactersStorage;
    [SerializeField] private PlayerItemStorage _itemStorage;

    public void Load(EquippedItemsData equippedItemsData)
    {
        CharacterItems characterItems;
        Item item;

        for (int i = 0; i < equippedItemsData.ItemsCount.Length; i++)
        {

            if (equippedItemsData.ItemsCount[i] > 0)
            {
                characterItems = _charactersStorage.GetCharacter(i).GetComponent<CharacterItems>();

                for(int j = 0; j < equippedItemsData.ItemsCount[i]; j++)
                {
                    item = _itemStorage.GetItem(equippedItemsData.ItemsID[i,j]);
                    characterItems.ChangeItem(item.Type, true, item, equippedItemsData.InHand[i,j]); ;
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
