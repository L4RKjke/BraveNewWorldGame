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

    private UnityAction<FighterType> _battleEnded;

    private void OnEnable()
    {
        _startButton.SetActive(true);
        _pool.SquadLose += PickWinner;
        _battleEnded += EndBattle;
    }

    private void OnDisable()
    {
        _pool.SquadLose -= PickWinner;
        _battleEnded -= EndBattle;
    }

    public void OnStart()
    {
       /*_canvasBar.SetActive(true);*/
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
            _finalPanels.End(true);
        else
            _finalPanels.End(false);

        /*_canvasBar.SetActive(false);*/

        _timer.StopTimer();
    }
}
