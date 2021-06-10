using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int _health = 28;

    bool _tookDamage;

    float invincibilityTime;

    Animator anim;

    void Start()
    { 
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_tookDamage)
        {
            anim.SetBool("TookDamage", true);
            GetComponent<PlayerMovement>().Knockback();
            _tookDamage = false;
        }
        else
            anim.SetBool("TookDamage", false);

        if (_health < 1)
            Die();
    }

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
        if (invincibilityTime < Time.realtimeSinceStartup)
        {
            _health -= damage;
            _tookDamage = true;

            invincibilityTime = Time.realtimeSinceStartup + 1f;
        }
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyBullet>().GetBulletDamage());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision.gameObject.GetComponent<ContactDamage>().GetContactDamage());
        }
    }
}
