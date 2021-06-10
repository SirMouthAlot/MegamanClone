using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Vector3 bulletSpawn;
    [SerializeField] float bulletSpeed;

    float timeToNextShot = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && CanShoot())
            ShootBullet();
    }

    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup)
        {
            timeToNextShot = Time.realtimeSinceStartup + 0.2f;
            return true;
        }
        else
            return false;
    }

    void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn + transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));

        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        Destroy(bullet, 5);
    }
}
