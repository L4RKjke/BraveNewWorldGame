using UnityEngine;

public class RestartArena : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;
    [SerializeField] private ArenaCells _arenaCells;

    public void OnRestart()
    {
        _pool.CleanPool();
        _arenaCells.PrepareArena();
    }
}
