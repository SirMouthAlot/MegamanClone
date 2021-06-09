using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject playerObj;

    Transform trans;
    PlayerMovement player;

    float moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();

        player = playerObj.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if(playerObj.transform.position.x - trans.position.x > 3 && moveDirection > 0)
            trans.position += transform.right * Time.deltaTime * player.GetSpeed();

        if (playerObj.transform.position.x - trans.position.x < -3 && moveDirection < 0)
            trans.position -= transform.right * Time.deltaTime * player.GetSpeed();
    }
}
