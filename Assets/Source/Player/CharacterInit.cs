using UnityEngine;

public class CharacterInit : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private LeyerController _leyerController;
    [SerializeField] private ViewDirection _viewDirection;
    [SerializeField] private AnimationCotroller _animationController;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        _healthBar.SetActive(true);
        _leyerController.enabled = true;
        _animationController.enabled = true;
        _viewDirection.enabled = true;
    }
}
