using UnityEngine;

public class FireBallInstantiator : MonoBehaviour
{
    private FighterType _targetType;

    public void Shoot(Fighter currentTarget, Fireball fireball, Transform firePoint, FighterType targetType, int damage)
    {
        _targetType = targetType;

        if (currentTarget != null)
        {
            if (currentTarget.transform.parent.position.x - firePoint.position.x < 0)
                InstantiateBullet(GetAngle(currentTarget, firePoint) + 180, fireball, firePoint, damage);
            else
                InstantiateBullet(GetAngle(currentTarget, firePoint), fireball, firePoint, damage);
        }
    }

    private void InstantiateBullet(float angel, Fireball fireball, Transform firePoint, int damage)
    {
        var newFireball = Instantiate(fireball, firePoint.position, Quaternion.Euler(new Vector3(0, 0, angel)));
        newFireball.Init(_targetType, damage);
    }

    private float GetAngle(Fighter currentTarget, Transform firePoint) => (180 / Mathf.PI) *
        Mathf.Atan((currentTarget.transform.position.y - firePoint.position.y) / (currentTarget.transform.position.x - firePoint.position.x));
}
