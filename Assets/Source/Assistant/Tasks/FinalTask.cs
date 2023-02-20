using UnityEngine.Events;
using UnityEngine;

public class FinalTask : AssistantTask
{
    [SerializeField] private Animator _animator;

    public UnityAction Trainingcompleted;

    private void OnEnable()
    {
        _animator.enabled = true;
        ShowMessage(this);
    }
}
