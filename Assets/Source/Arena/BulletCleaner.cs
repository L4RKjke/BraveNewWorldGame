using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class BulletCleaner : MonoBehaviour
{
    private float _time = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fireball projectile))
        {
            Destroy(projectile.gameObject);
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= 0.1f)
        {
            _time = 0;
            this.gameObject.SetActive(false);
        }
    }
}