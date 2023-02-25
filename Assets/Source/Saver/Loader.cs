using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoadGame))]
public class Loader : MonoBehaviour
{
    private SaveLoadGame _game;

    private void Start()
    {
        _game = GetComponent<SaveLoadGame>();
        _game.Load();
    }

    private IEnumerator CoroutineLoadDelay()
    {
        float delay = 1;
        yield return new WaitForSeconds(delay);
        _game = GetComponent<SaveLoadGame>();
        _game.Load();
    }
}
