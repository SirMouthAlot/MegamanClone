using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAnimations : MonoBehaviour
{
    Animator anim;

    FrogShooting frog;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        frog = GetComponent<FrogShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frog.GetIsShooting())
        {
            anim.SetBool("Shooting", true);
            frog.SetIsShooting(false);
        }
        else
            anim.SetBool("Shooting", false);
    }
}
