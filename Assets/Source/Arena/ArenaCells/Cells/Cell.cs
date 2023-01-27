using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool _isFull = false;
    private bool _isBuildingStay = false;
    private bool _isPlaceble;
    private int _transformX;
    private int _transformY;

    public bool IsPlaceble => _isPlaceble;

    public bool IsBuildingStay => _isBuildingStay;

    public bool IsFull => _isFull;

    public int TransformX => _transformX;

    public int TransformY => _transformY;

    public void Init(int x, int y)
    {
        _transformX = x;
        _transformY = y;
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
