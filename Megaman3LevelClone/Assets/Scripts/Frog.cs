using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    int _health = 2;
    int _bulletDamage = 2;

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
