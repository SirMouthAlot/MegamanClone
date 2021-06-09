using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator anim;

    PlayerMovement playerMove;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.GetIsWalking())
            anim.SetBool("Walking", true);
        else
            anim.SetBool("Walking", false);

        if (playerMove.GetIsGrounded())
            anim.SetBool("InAir", false);
        else
            anim.SetBool("InAir", true);

        if (player.GetTookDamage())
        {
            anim.SetBool("TookDamage", true);
            player.SetTookDamage(false);
        }
        else
            anim.SetBool("TookDamage", false);
    }
}
