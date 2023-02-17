using UnityEngine;

public class BuyWarriorCondition : Condition
{
    [SerializeField] private CharactersStorage _charactersStorage;

    private void Update()
    {
        if (_charactersStorage.GetLenght() != 0)
        {
            NeedTransit = true;
        }
    }
}