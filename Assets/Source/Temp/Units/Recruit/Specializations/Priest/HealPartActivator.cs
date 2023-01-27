using UnityEngine;

public class HealPartActivator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _healCircle;
    [SerializeField] private ParticleSystem _sesondaryEffect;

    public void Play()
    {
        _healCircle.Play();
        _sesondaryEffect.Play();
    }

    private void OnEnable()
    {
        Play();
    }
}
