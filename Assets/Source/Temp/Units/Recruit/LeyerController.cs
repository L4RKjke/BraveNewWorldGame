using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SortingGroup))]

public class LeyerController : MonoBehaviour
{
    [SerializeField] private Fighter _unit;

    private SortingGroup _sortingGroup;
    private int _primaryLayerId = 200;

    private void Start()
    {
        _sortingGroup = GetComponent<SortingGroup>();
        _primaryLayerId = _sortingGroup.sortingOrder;
    }

    private void FixedUpdate()
    {
        _sortingGroup.sortingOrder = _primaryLayerId - _unit.Units.GetHorizontalIndex(_unit);
    }
}

