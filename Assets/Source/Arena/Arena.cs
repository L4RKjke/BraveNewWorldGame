using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Arena:  MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private SquadHealthbar _playerHealthbar;
    [SerializeField] private SquadHealthbar _enemyHealthbar;
    [SerializeField] private FinalPanels _finalPanels;
    [SerializeField] private SquadHealthbar _PlayerHealthbar;
    [SerializeField] private SquadHealthbar _EnemyHealthbar;

    private void OnEnable()
    {
        _startButton.SetActive(true);
        _PlayerHealthbar.HealthOver += OnEnemyWin;
        _EnemyHealthbar.HealthOver += OnPlayerWin;
    }

    private void OnDisable()
    {
        _PlayerHealthbar.HealthOver -= OnEnemyWin;
        _EnemyHealthbar.HealthOver -= OnPlayerWin;
    }

    public void OnStartButtonClick()
    {
        _arenaCells.BuildBanMesh();
        _playerHealthbar.UpdateHealthbar();
        _enemyHealthbar.UpdateHealthbar();

        for (int i = 0; i < _pool.GetLength(); i++)
        {
        _pool.GetById(i).transform.parent.gameObject.GetComponent<NavMeshAgent>().enabled = true;
        _pool.GetById(i).transform.gameObject.SetActive(true);

        var parent = _pool.GetById(i).transform.parent.gameObject;
            parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z + 0.1f);
        }

        _arenaCells.PlayStartBattle();
        _startButton.SetActive(false);
        _timer.StartTimer();
    }

    private void OnPlayerWin()
    {
        _finalPanels.End(true);
        _timer.StopTimer();
    }

    private void OnEnemyWin()
    {
        _finalPanels.End(false);
        _timer.StopTimer();
    }
}
