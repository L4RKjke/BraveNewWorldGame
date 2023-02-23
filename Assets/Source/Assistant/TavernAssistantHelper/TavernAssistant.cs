using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernAssistant : MonoBehaviour
{
    [SerializeField] private Transform _tavernContainer;

    private void Start()
    {
        HideCharacters(2);
    }

    public void HideCharacters(int visibleCharacter)
    {
        visibleCharacter -= 1;

        for(int i = 0; i < _tavernContainer.childCount; i++)
        {
            if(i != visibleCharacter)
                _tavernContainer.GetChild(i).gameObject.SetActive(false);
        }
    }
}
