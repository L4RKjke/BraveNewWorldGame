using UnityEngine;
using UnityEngine.AI;

public class StartBattle : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;
    [SerializeField] private GameObject _startButton;

    public void OnStartButtonClick()
    {
        for (int i = 0; i < _pool.GetLength(); i++)
        {
            _pool.GetById(i).transform.parent.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            _pool.GetById(i).transform.gameObject.SetActive(true);

            if (_pool.GetById(i).EnemyType == FighterType.Enemy)
            {
                var parent = _pool.GetById(i).transform.parent.parent.gameObject;
                _pool.GetById(i).transform.parent.SetParent(null);
                Destroy(parent);
            }
        }

        _arenaCells.PlayStartBattle();
        _startButton.SetActive(false);
    }
}
