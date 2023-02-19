using UnityEngine;

public class BattleTask : AssistantTask
{
    [SerializeField] private GameObject _dragAnimation;

    private void OnEnable()
    {
        ShowMessage(this);
        _dragAnimation.SetActive(true);
    }

    private void OnDisable()
    {
        if (_dragAnimation != null)
            _dragAnimation?.SetActive(false);
    }
}
