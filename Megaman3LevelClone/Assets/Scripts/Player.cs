using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _health = 28;
    int _bulletDamage = 1;

    bool _tookDamage;

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
        _tookDamage = true;
        _health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public bool GetTookDamage()
    {
        return _tookDamage;
    }

    public void SetTookDamage(bool tookDamage)
    {
        _tookDamage = tookDamage;
    }
}
