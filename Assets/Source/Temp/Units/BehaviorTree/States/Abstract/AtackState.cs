using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public abstract class AtackState : State
{
    [SerializeField] private AnimationCotroller _animationController;

    protected AnimationCotroller AnimationController => _animationController;

    public float FirstDelaySpread => Random.Range(0.1f, 0.25f);

    public UnityAction AtackStarted;
    public UnityAction AtackCompleted;
    public UnityAction StateActivated;

    protected int Damage => CurrentFighter.Damage;

    protected abstract void StartAtack();

    protected abstract void CompleteAtack();

    protected IEnumerator LaunchAtack(float atackDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(atackDelay);
            StartAtack();
        }
    }
}
