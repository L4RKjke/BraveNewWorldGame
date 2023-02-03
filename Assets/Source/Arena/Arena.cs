using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Arena:  MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;
    [SerializeField] private SquadHealthbar _enemyHealthbar;
    [SerializeField] private SquadHealthbar _playerHealthbar;

    private UnityAction<FighterType> _battleEnded;

    private void OnEnable()
    {
        _pool.SquadLose += PickWinner;
        _battleEnded += EndBattle;
    }

    private void OnDisable()
    {
        _pool.SquadLose -= PickWinner;
        _battleEnded -= EndBattle;
    }

    public void RestartArena()
    {
        _pool.CleanPool();
        _arenaCells.PrepareArena();
        _panelWin.SetActive(false);
        _panelLose.SetActive(false);
        _startButton.SetActive(true);
        _playerHealthbar.enabled = true;
        _enemyHealthbar.enabled = true;
    }

    public void OnStartButtonClick()
    {
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

    private void PickWinner(FighterType type)
        {
        FighterType result;

        if (type == FighterType.Recruit)
            result = FighterType.Enemy;
        else
            result = FighterType.Recruit;

        _battleEnded?.Invoke(result);
        }

    private void EndBattle(FighterType type)
    {
        if (type == FighterType.Recruit)
            _panelWin.SetActive(true);
        else
            _panelLose.SetActive(true);

        _timer.StopTimer();
        _playerHealthbar.enabled = false;
        _enemyHealthbar.enabled = false;
    }
}
