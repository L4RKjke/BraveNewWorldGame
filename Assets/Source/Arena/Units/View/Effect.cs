using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public abstract class Effect : MonoBehaviour
{
    private ParticleSystem _effect;

    protected ParticleSystem ParticalEffect => _effect;

    private void Start()
    {
        _effect = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        _effect.Play();
    }

    protected void Move(Fighter fighter)
    {
        transform.position = fighter.RootModel.transform.position;
    }
}