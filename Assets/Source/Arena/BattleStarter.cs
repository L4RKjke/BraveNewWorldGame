using UnityEngine;
using UnityEngine.AI;

public class BattleStarter : MonoBehaviour
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
            else
            {
                var parent = _pool.GetById(i).transform.parent.gameObject;
                parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z + 0.1f);
            }
        }

        _arenaCells.PlayStartBattle();
        _startButton.SetActive(false);
    }
}
