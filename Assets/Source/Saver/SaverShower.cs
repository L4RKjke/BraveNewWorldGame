using UnityEngine;

public class SaverShower : MonoBehaviour
{
    [SerializeField] private SaveLoadGame _saver;
    [SerializeField] private Animator _animator;

    public void OnEnable()
    {
        _saver.Saved += Show;
    }

    public void OnDisable()
    {
        _saver.Saved -= Show;
    }

    private void Show()
    {
        string Save = "Save";

        _animator.SetTrigger(Save);
    }
}
