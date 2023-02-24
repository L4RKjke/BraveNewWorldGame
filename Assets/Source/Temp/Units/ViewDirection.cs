using UnityEngine;

public class ViewDirection : MonoBehaviour
{
    [SerializeField] private Fighter _unit;
    [SerializeField] private FaceDirection _baseDirection;

    private Vector2 _defoaltScale;
    private Vector2 _invertedScale;
    private FaceDirection _currentDirection;

    private void Start()
    {
        _currentDirection = _baseDirection;
        _invertedScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        _defoaltScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    private void FixedUpdate()
    {
        Flip();
    }

    private void Flip()
    {
        if (_baseDirection == FaceDirection.Right)
            Rotate(_invertedScale, _defoaltScale);

        else
            Rotate(_defoaltScale, _invertedScale);

    }
    // подумать как убрать дубляж кода, как минумум можно просто убрать 2 иф, он не нужен
    private void Rotate(Vector2 leftScale, Vector2 rightScale)
    {
        if (_unit.CurrentTarget != null)
        {
            if ((_unit.CurrentTarget.transform.position.x > transform.position.x) && (_currentDirection != FaceDirection.Left))
            {
                transform.localScale = leftScale;
                _currentDirection = FaceDirection.Left;
            }

            if (_unit.CurrentTarget.transform.position.x <= transform.position.x && _currentDirection != FaceDirection.Right)
            {
                transform.localScale = rightScale;
                _currentDirection = FaceDirection.Right;
            }
        }
    }
}

public enum FaceDirection
{
    Left,
    Right
}
