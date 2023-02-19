using UnityEngine;

public class DragAnimation : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;

    private void Update()
    {
        if (_pool.GetLength() > 0)
        {
            transform.parent.position = _pool.GetById(0, FighterType.Recruit).transform.parent.transform.parent.transform.position;
            enabled = false;
        }
    }
}
