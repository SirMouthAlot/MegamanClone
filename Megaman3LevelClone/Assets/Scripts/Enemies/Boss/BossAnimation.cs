using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    Animator anim;

    BossShooting boss;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boss = GetComponent<BossShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetIsShooting())
        {
            anim.SetBool("Shooting", true);
            boss.SetIsShooting(false);
        }
        else
            anim.SetBool("Shooting", false);
    }
}
