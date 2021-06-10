using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperMovement : MonoBehaviour
{
    [SerializeField] float bigJumpHeight;
    [SerializeField] float smallJumpHeight;
    [SerializeField] float horiztonalMoveSpeed;
    [SerializeField] Transform playerTrans;

    Rigidbody2D body;

    bool isGrounded;
    int cycleIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            JumpCycle();
        }

        if (Mathf.Abs(playerTrans.position.x - transform.position.x) < 22)
        {
            MoveForwards();
        }

        cycleIndex = Mathf.Clamp(cycleIndex, 1, 3);
    }

    void JumpCycle()
    {
        if (cycleIndex == 1)
        {
            BigJump();
            cycleIndex++;
        }
        else if (cycleIndex == 2)
        {
            SmallJump();
            cycleIndex++;
        }
        else if (cycleIndex == 3)
        {
            SmallJump();
            cycleIndex = 1;
        }
    }

    void BigJump()
    {
        body.AddForce(transform.up * bigJumpHeight, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void SmallJump()
    {
        body.AddForce(transform.up * smallJumpHeight, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void MoveForwards()
    {
        //if (playerTrans.position.x - transform.position.x <= 0)
        //{
        //    body.velocity = new Vector2(-horiztonalMoveSpeed, body.velocity.y);
        //}
        //else if (playerTrans.position.x - transform.position.x > 0)
        //{
        //    body.velocity = new Vector2(horiztonalMoveSpeed, body.velocity.y);
        //}

        body.velocity = new Vector2(-horiztonalMoveSpeed, body.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0.5)
                    isGrounded = true;
            }
        }
    }
}
