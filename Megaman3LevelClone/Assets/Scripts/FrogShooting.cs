using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogShooting : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    Renderer renderer;

    float timeToNextShot = 0;
    bool isShooting;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanShoot())
        {
            isShooting = true;
            Shoot();
        }
    }

    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup && renderer.isVisible)
        {
            timeToNextShot = Time.realtimeSinceStartup + 3f;
            return true;
        }
        else
            return false;
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = (playerTrans.position - transform.position).normalized * bulletSpeed;

        Destroy(bullet, 5);
    }

    public bool GetIsShooting()
    {
        return isShooting;
    }

    public void SetIsShooting(bool shoot)
    {
        isShooting = shoot;
    }
}
