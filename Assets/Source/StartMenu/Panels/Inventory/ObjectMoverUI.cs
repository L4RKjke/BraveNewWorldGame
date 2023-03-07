using UnityEngine;
using UnityEngine.UI;

public class ObjectMoverUI : MonoBehaviour
{
    [SerializeField] private RectTransform _movingObject;

    private InventoryUI _inventoryUI;
    private Vector3 _offSet = new(1, -1, 0);
    private float _positionZ;

    public RectTransform MovingObject => _movingObject;


    private void Update()
    {
        if (_inventoryUI.CurrentId != -1)
            MoveObject();
    }

    public void MoveSetActive(bool isTrue)
    {
        _movingObject.gameObject.SetActive(isTrue);
    }

    public void SetSprite(Sprite sprite)
    {
        _movingObject.GetComponent<Image>().sprite = sprite;
    }

    public void Init(InventoryUI inventoryUI, float positionZ)
    {
        _inventoryUI = inventoryUI;
        _positionZ = positionZ;
    }

    private void MoveObject()
    {
        Vector3 position = Input.mousePosition + _offSet;
        position.z = _positionZ;
        _movingObject.position = Camera.main.ScreenToWorldPoint(position);
    }
}
