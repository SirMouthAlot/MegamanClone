using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int bulletDamage = 1;


    public int GetBulletDamage()
    {
        return bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            Destroy(gameObject);
    }
}
