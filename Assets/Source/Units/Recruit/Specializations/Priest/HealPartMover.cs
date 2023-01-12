using UnityEngine;

public class HealPartMover : MonoBehaviour
{
    private Fighter _target;

    public void Init(Fighter target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target != null)
            transform.position = _target.HealPoint.position;
    }
}
