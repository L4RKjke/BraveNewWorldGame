using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    ///Example

    [SerializeField] private GameObject[] _recruitTemplates;
    [SerializeField] private GameObject[] _enemieTemplate;
    [SerializeField] private Transform[] _enemiesSpawnPoints;
    [SerializeField] private Transform[] _recruitsSpawnPoints;
    [SerializeField] private FighterType _recruitType;
    [SerializeField] private FighterType _enemieType;
    [SerializeField] private UnitPool _fighters;

    private List<Fighter> _recruits = new List<Fighter> { };
    private List<Fighter> _enemies = new List<Fighter> { };

    public int EnemiesCount { get; private set; }
    public int RecruitsCount { get; private set; }

    private void Start()
    {
        EnemiesCount = 1;
        RecruitsCount = 1;
        CreateEnemies();
        CreatePlayerUnits();
    }

    private void CreateEnemies()
    {
        CreateUnits(EnemiesCount, _enemieTemplate, _fighters, _enemiesSpawnPoints, _enemieType, _recruitType);
    }

    private void CreatePlayerUnits()
    {
        CreateUnits(RecruitsCount, _recruitTemplates, _fighters, _recruitsSpawnPoints, _recruitType, _enemieType);
    }

    private void CreateUnits(int unitCount, GameObject[] templates, UnitPool units, Transform[] positions, FighterType type, FighterType enemyType)
    {
        for (int i = 0; i < unitCount; i++)
        {
            var newFighter = Instantiate(templates[0], new Vector2(positions[i].position.x, positions[i].position.y), Quaternion.identity).GetComponent<Fighter>();

            newFighter.Init(type, enemyType, _fighters, 10, 150);
            units.AddNewFighter(newFighter);
        }
    }
}
