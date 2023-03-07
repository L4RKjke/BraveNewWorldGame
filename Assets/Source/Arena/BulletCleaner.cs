using UnityEngine;

[RequireComponent(typeof(Collider2D))] //isTrigger (�������)
[RequireComponent(typeof(Rigidbody2D))] // Static, simulated (�������))

public class BulletCleaner : MonoBehaviour
{
    private float time = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fireball projectile))
        {
            Destroy(projectile.gameObject);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= 0.1f)
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
    }
}