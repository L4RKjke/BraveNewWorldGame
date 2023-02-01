using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Arena : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelLose;

    private string _finalText = "";

    private void OnEnable()
    {
        _pool.UnitDied += VerifyUnits;
    }

    private void OnDisable()
    {
        _pool.UnitDied += VerifyUnits;
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

    private void VerifyUnits(FighterType type) 
    {
        if (_pool.GetLength(type) == 0)
        {
            if (type == FighterType.Recruit)
            {
                _finalText = "Lose!";
                _panelLose.SetActive(true);
            }
            else
            {
                _finalText = "Win!";
                _panelWin.SetActive(true);
            }

            EndBattle();
        }

    }

    private void EndBattle()
    {
        _timer.StopTimer();
    }
}
