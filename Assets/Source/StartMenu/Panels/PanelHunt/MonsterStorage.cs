using System.Collections.Generic;
using UnityEngine;

public class MonsterStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _monsters;

    public GameObject  GetMonster(int id)
    {
        return _monsters[id];
    }

    public MonsterInfo GetMonsterInfo(int id)
    {
        return _monsters[id].GetComponent<MonsterInfo>();
    }
}
