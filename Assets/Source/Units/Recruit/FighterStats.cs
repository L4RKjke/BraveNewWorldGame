using UnityEngine;

public class FighterStats : MonoBehaviour
{
    public int Health { get; private set ; }

    public int Damage { get; private set; }

    public void ChangeHealth(int health)
    {
        Health = health; 
    }

    public void ChangeDamage(int damage)
    {
        Damage = damage;
    }

}
