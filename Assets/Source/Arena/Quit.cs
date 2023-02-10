using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField] private GameObject _arena;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private RestartArena _restart;

    public void AtivateArena()
    {
        _restart.OnRestart();
        _arena.SetActive(true);
        _canvas.SetActive(false);
    }

    public void DisableArena()
    {

        _arena.SetActive(false);
        _canvas.SetActive(true);
    }
}
