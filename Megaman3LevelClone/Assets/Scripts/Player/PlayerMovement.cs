using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform trans;
    Rigidbody2D body;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float knockbackPower;

    float playerGravity = 15;

    bool isWalking;
    bool isGrounded;
    bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isClimbing)
        {
            if (Input.GetKey(KeyCode.D))
            {
                trans.position += transform.right * Time.deltaTime * speed;
                trans.rotation = Quaternion.Euler(0, 0, 0);
                isWalking = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                trans.position += transform.right * Time.deltaTime * speed;
                trans.rotation = Quaternion.Euler(0, 180, 0);
                isWalking = true;
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                isWalking = false;
            }

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        if (isClimbing)
        {
            body.gravityScale = 0;
            body.drag = 50;
            ClimbMovement();
        }
        else
        {
            body.gravityScale = playerGravity;
            body.drag = 0;
        }
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }

    void ClimbMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            trans.position += transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            trans.position -= transform.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            trans.position += transform.right * Time.deltaTime * speed;
            trans.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Knockback()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * knockbackPower, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddForce(-transform.right * knockbackPower, ForceMode2D.Impulse);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public bool GetIsClimbing()
    {
        return isClimbing;
    }
}
