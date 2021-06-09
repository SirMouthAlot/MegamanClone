using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform trans;
    Rigidbody2D body;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    bool isWalking;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
            isWalking = false;


        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
}
