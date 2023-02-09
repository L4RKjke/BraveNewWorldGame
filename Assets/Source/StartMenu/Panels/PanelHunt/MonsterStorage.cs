using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStorage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _monsters;

    public MonsterInfo GetMonsterInfo(int id)
    {
        return _monsters[id].GetComponent<MonsterInfo>();
    }
}
