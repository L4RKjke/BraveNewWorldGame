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

    public UnityAction<FighterType> SquadEmpty;

    private void OnEnable()
    {
        _startButton.SetActive(true);
        _pool.UnitDied += PickTheWinner;
    }

    private void OnDisable()
    {
        _pool.UnitDied -= PickTheWinner;
    }

    public void OnStartButtonClick()
    {
        _arenaCells.BuildBanMesh();

        for (int i = 0; i < _pool.GetLength(); i++)
        {
            _pool.GetById(i).transform.parent.gameObject.GetComponent<NavMeshRootController>().enabled = true;
            _pool.GetById(i).transform.gameObject.SetActive(true);

            var parent = _pool.GetById(i).transform.parent.gameObject;
            parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z + 0.1f);
        }

        _playerHealthbar.UpdateHealthbar();
        _enemyHealthbar.UpdateHealthbar();
        _arenaCells.PlayStartBattle();
        _startButton.SetActive(false);
        _timer.StartTimer();
    }

    private void OnPlayerWin()
    {
        Debug.Log(" онец");
        _finalPanels.End(true);
        _timer.StopTimer();
    }

    private void OnEnemyWin()
    {
        _finalPanels.End(false);
        _timer.StopTimer();

        //мб временно, есть баг с тем, что могут умереть одновременно и враг и игрок
    }

    private void PickTheWinner(FighterType type)
    {
        if (_pool.GetLength(type) == 0)
        {
            if (type == FighterType.Enemy)
                OnPlayerWin();

            else
                OnEnemyWin();
        }
    }
}