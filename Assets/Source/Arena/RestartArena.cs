using UnityEngine;
using UnityEngine.AI;

public class RestartArena : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private SquadHealthbar _playerHealth;
    [SerializeField] private SquadHealthbar _enemyHealth;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private BulletCleaner _bulletCleaner;

    public void OnRestart()
    {
        _bulletCleaner.gameObject.SetActive(true);
        _buttons.SetActive(true);
        _playerHealth.UpdateHealthbar();
        _enemyHealth.UpdateHealthbar();
        _pool.CleanPool();
        _arenaCells.PrepareArena();
        _timer.ResetTimer();
        _startButton.SetActive(true);
    }
}
