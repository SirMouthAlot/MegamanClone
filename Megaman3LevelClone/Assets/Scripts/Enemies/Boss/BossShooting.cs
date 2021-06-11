using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    [SerializeField] Transform playerTrans;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    Renderer renderer;

    float timeToNextShot = 0;
    bool isShooting;

    bool initialDelayApplied;

    int cycleIndex = 1;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible && !initialDelayApplied)
        {
            timeToNextShot = Time.realtimeSinceStartup + 2f;
            initialDelayApplied = true;
        }

        ShootCycle();
    }

    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup && renderer.isVisible)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        bullet.GetComponent<Rigidbody2D>().velocity = (playerTrans.position - transform.position).normalized * bulletSpeed;

        Destroy(bullet, 3);
    }

    void ShortDelay()
    {
        timeToNextShot = Time.realtimeSinceStartup + 0.2f;
    }

    void LongDelay()
    {
        timeToNextShot = Time.realtimeSinceStartup + 3f;
    }

    void ShootCycle()
    {
        if (CanShoot())
        {
            isShooting = true;
            Shoot();

            if (cycleIndex == 1 || cycleIndex == 2)
            {
                ShortDelay();
                cycleIndex++;
            }
            else if (cycleIndex == 3)
            {
                LongDelay();
                cycleIndex = 1;
            }
        }
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
