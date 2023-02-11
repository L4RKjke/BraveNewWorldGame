using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshModifier))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour
{
    private bool _isFull = false;
    private bool _isBuildingStay = false;
    private bool _isPlaceble;
    private int _transformX;
    private int _transformY;
    private NavMeshModifier _modifier;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    public BoxCollider2D Collider => _boxCollider;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public bool IsPlaceble => _isPlaceble;

    public bool IsBuildingStay => _isBuildingStay;

    public bool IsFull => _isFull;

    public int Row => _transformX;

    public int Column => _transformY;

    private void Awake()
    {
        _modifier = GetComponent<NavMeshModifier>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>(); 
    }

    public void Init(int x, int y)
    {
        _transformX = x;
        _transformY = y;
    }

    public void MakeUnwalkable()
    {
        _modifier.area = 1;
    }

    public void MakeUnplaceble()
    {
        _isPlaceble = false;
    }

    public void ChangeStayCharacter()
    {
        _isBuildingStay = !_isBuildingStay;
    }

    public void ChangeFull()
    {
        _isFull = !_isFull;
        _isBuildingStay = !_isBuildingStay;

        GetComponent<BoxCollider2D>().enabled = !_isFull;
    }
}
