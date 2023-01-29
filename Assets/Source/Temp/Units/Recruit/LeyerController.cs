using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(SortingGroup))]

public class LeyerController : MonoBehaviour
{
    [SerializeField] private UnitPool _pool;

    private SortingGroup _sortingGroup;
    private int _primaryLayerId = 200;

    private void Start()
    {
        _sortingGroup = GetComponent<SortingGroup>();
        _primaryLayerId = _sortingGroup.sortingOrder;
    }

    private void FixedUpdate()
    {
        float start = -4;
        float end = 4;
        int counter = 0;

        while (start <= end)
        {
            counter++;
            start += 0.5f;

            if (transform.position.y < start)
            {
                _sortingGroup.sortingOrder = _primaryLayerId - counter;
                break;
            }
        }
    }
}

