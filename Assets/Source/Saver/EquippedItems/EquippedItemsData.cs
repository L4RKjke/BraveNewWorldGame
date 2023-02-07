using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquippedItemsData
{
    public int[] ItemsCount;
    public int[,] ItemsID;
    public bool[,] InHand;

    public EquippedItemsData(CharactersStorage charactersStorage)
    {
        int itemsCount = 5;
        ItemsCount = new int[charactersStorage.AllCharacters];
        ItemsID = new int[charactersStorage.AllCharacters, itemsCount];
        InHand = new bool[charactersStorage.AllCharacters, itemsCount];

        int count = 0;

        for (int i = 0; i < charactersStorage.AllCharacters; i++)
        {
            GameObject character = charactersStorage.GetCharacter(i);
            CharacterItems characterItems = character.GetComponent<CharacterItems>();
            Item item = characterItems.GetItem(ItemType.Weapon);
            count = AddItem(item,i,count);
            item = characterItems.GetItem(ItemType.Hand);

            if (item != null)
            {
                ItemsID[i, count] = item.Id;

                if(item.GetComponent<WeaponItem>() == true)
                {
                    InHand[i, count] = true;
                }
                else
                {
                    InHand[i, count] = false;
                }

                count++;
            }

            item = characterItems.GetItem(ItemType.Head);
            count = AddItem(item, i, count);
            item = characterItems.GetItem(ItemType.Body);
            count = AddItem(item, i, count);
            item = characterItems.GetItem(ItemType.Leg);
            count = AddItem(item, i, count);

            ItemsCount[i] = count;
            count = 0;
        }
    }

    private int AddItem(Item item, int firstID, int SecondID)
    {
        if (item != null)
        {
            ItemsID[firstID, SecondID] = item.Id;
            InHand[firstID, SecondID] = false;
            SecondID++;
        }

        return SecondID;
    }
}
