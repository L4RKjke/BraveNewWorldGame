using UnityEngine;

public class FireBallInstantiator : MonoBehaviour
{
    public void Shoot(Fighter currentTarget, Fireball fireball, Transform firePoint)
    {
        if (currentTarget != null)
        {
            if (currentTarget.transform.parent.position.x - firePoint.position.x < 0)
                InstantiateBullet(GetAngle(currentTarget, firePoint) + 180, fireball, firePoint);
            else
                InstantiateBullet(GetAngle(currentTarget, firePoint), fireball, firePoint);
        }
    }

    private void InstantiateBullet(float angel, Fireball fireball, Transform firePoint)
    {
        Instantiate(fireball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, angel)));
    }

    private float GetAngle(Fighter currentTarget, Transform firePoint) => (180 / Mathf.PI) *
        Mathf.Atan((currentTarget.transform.position.y - firePoint.position.y) / (currentTarget.transform.position.x - firePoint.position.x));
}
