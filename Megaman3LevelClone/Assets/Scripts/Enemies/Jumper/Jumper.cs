using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    int _health = 1;

    void Update()
    {
        if (_health < 1)
            Die();
    }

    public int GetHealth()
    {
        return _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player Bullet" && GetComponent<Renderer>().isVisible)
        {
            TakeDamage(collision.gameObject.GetComponent<PlayerBullet>().GetBulletDamage());
        }
    }
}
