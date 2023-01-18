using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayerUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _characters;
    [SerializeField] private Transform _pointToCreate;
    [SerializeField] private GameObject _foldingScreen;

    private GameObject _currentCharacter;

    private void Start()
    {
        float delay = 0.5f;
        StartCoroutine(Delay(delay,0));
    }

    private void ShowCharacter(int id)
    {
        _currentCharacter = Instantiate(_characters[id], _pointToCreate);
        _currentCharacter.GetComponent<StateMachine>().enabled = false;
        _currentCharacter.transform.position = _pointToCreate.position;
        _currentCharacter.transform.localScale = new Vector3(80f, 80f, 1);
    }

    private IEnumerator Delay(float delay, int id)
    {
        yield return new WaitForSeconds(delay);

        _foldingScreen.SetActive(true);
        float delayScreen = 0.25f;
        yield return new WaitForSeconds(delayScreen);

        ShowCharacter(id);
    }
}
