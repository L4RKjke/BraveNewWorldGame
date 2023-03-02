using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquippedItemsData
{
    private List<EquipItemData> _items = new List<EquipItemData>();

    public EquippedItemsData(CharactersStorage charactersStorage)
    {
        int itemsCount = 5;
        int count = 0;

        for (int i = 0; i < charactersStorage.AllCharacters; i++)
        {
            _items.Add(new EquipItemData());
            _items[i].Init(itemsCount);
            GameObject character = charactersStorage.GetCharacter(i);
            CharacterItems characterItems = character.GetComponent<CharacterItems>();
            Item item = characterItems.GetItem(ItemType.Weapon);
            count = AddItem(item,i,count);
            item = characterItems.GetItem(ItemType.Hand);

            if (item != null)
            {
                _items[i].SetId(count, item.Id);

                if(item.GetComponent<WeaponItem>() == true)
                {
                    _items[i].SetInHand(count, true);
                }
                else
                {
                    _items[i].SetInHand(count, false);
                }

                count++;
            }

            item = characterItems.GetItem(ItemType.Head);
            count = AddItem(item, i, count);
            item = characterItems.GetItem(ItemType.Body);
            count = AddItem(item, i, count);
            item = characterItems.GetItem(ItemType.Leg);
            count = AddItem(item, i, count);

            _items[i].SetCount(count);
            count = 0;
        }
    }

    public List<EquipItemData> GetItems()
    {
        return _items;
    }

    private int AddItem(Item item, int firstID, int SecondID)
    {
        if (item != null)
        {
            _items[firstID].SetId(SecondID, item.Id);
            _items[firstID].SetInHand(SecondID, false);
            SecondID++;
        }

        return SecondID;
    }
}
