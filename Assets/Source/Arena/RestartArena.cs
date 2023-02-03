using UnityEngine;

public class RestartArena : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private SquadHealthbar _enemyHealthbar;
    [SerializeField] private SquadHealthbar _playerHealthbar;

    public void OnRestart()
    {
        _pool.CleanPool();
        _arenaCells.PrepareArena();
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        _startButton.SetActive(true);
        _playerHealthbar.enabled = true;
        _enemyHealthbar.enabled = true;
    }
}
