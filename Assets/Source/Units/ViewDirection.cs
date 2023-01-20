using UnityEngine;

public class ViewDirection : MonoBehaviour
{
    [SerializeField] private GameObject CharacterView;
    [SerializeField] private FaceDirection _baseDirection;
    [SerializeField] private Fighter _fighter;

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
        if (_fighter.CurrentTarget != null)
        {
            if (_baseDirection == FaceDirection.Right)
            {
                if (_fighter.CurrentTarget.transform.position.x > _fighter.transform.position.x)
                {
                    transform.localScale = _invertedScale;
                    _currentDirection = FaceDirection.Left;
                }
                    
                else
                {
                    transform.localScale = _defoaltScale;
                    _currentDirection = FaceDirection.Right;
                }

            }

            else
            {
                if (_fighter.CurrentTarget.transform.position.x > _fighter.transform.position.x)
                {
                    transform.localScale = _defoaltScale;
                    _currentDirection = FaceDirection.Right;
                }

                else
                {
                    transform.localScale = _invertedScale;
                    _currentDirection = FaceDirection.Left;
                }
            }
        }
    }

/*    private Vector2 GetDirection(Vector2 defoaltScale, Vector2 invertedScale)
    {
        if (_fighter.CurrentTarget.transform.position.x > _fighter.transform.position.x)
        {
            transform.localScale = defoaltScale;
            _currentDirection = FaceDirection.Right;
        }
        else
        {
            transform.localScale = invertedScale;
            _currentDirection = FaceDirection.Left;
        }
    }*/
}

public enum FaceDirection
{
    Left,
    Right
}
