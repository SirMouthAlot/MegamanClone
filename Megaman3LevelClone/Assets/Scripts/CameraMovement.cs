using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject playerObj;

    Transform trans;
    PlayerMovement player;

    int cameraView = 1;

    bool isChanging;
    bool movingUp;
    bool movingDown;

    ////For Lerping////
    Vector3 currentPos;
    Vector3 nextPos;

    float speed = 1;

    float currentSize;
    float targetSize;

    float totalTime;
    float t;
    ///////////////////
    
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();

        player = playerObj.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = trans.position;
        currentSize = GetComponent<Camera>().orthographicSize;

        if(playerObj.transform.position.x - trans.position.x > 3)
        {
            trans.position += transform.right * Time.deltaTime * player.GetSpeed();
        }
        if (playerObj.transform.position.x - trans.position.x < -3)
        {
            trans.position -= transform.right * Time.deltaTime * player.GetSpeed();
        }


        if (trans.position.y == 2)
        {
            cameraView = 1;
        }
        else if (trans.position.y == 27)
        {
            cameraView = 2;
        }
        else if (trans.position.y == 58)
        {
            cameraView = 3;
        }

        if (cameraView == 1 && playerObj.transform.position.y >= 11)
        {
            ChangeCameraView();
        }
        if (cameraView == 2 && playerObj.transform.position.y < 11)
        {
            movingDown = true;
            movingUp = false;
            ChangeCameraView();
        }
        if (cameraView == 2 && playerObj.transform.position.y >= 39)
        {
            movingUp = true;
            movingDown = false;
            ChangeCameraView();
        }
        if (cameraView == 3 && playerObj.transform.position.y < 39)
        {
            ChangeCameraView();
        }


        if (isChanging)
        {
            UpdateCameraChange();
        }
    }

    void ChangeCameraView()
    {
        if (cameraView == 1)
        {
            targetSize = 11;
            nextPos = new Vector3(58, 27, -10);
        }
        else if (cameraView == 2 && movingDown)
        {
            targetSize = 7;
            nextPos = new Vector3(58, 2, -10);
        }
        else if (cameraView == 2 && movingUp)
        {
            targetSize = 8;
            nextPos = new Vector3(50, 58, -10);
        }
        else if (cameraView == 3)
        {
            targetSize = 11;
            nextPos = new Vector3(58, 27, -10);
        }

        totalTime = (nextPos - currentPos / speed).magnitude;

        isChanging = true;
    }

    void UpdateCameraChange()
    {
        t += Time.deltaTime / totalTime;

        if (t < 0f)
            t = 0f;

        if (t >= 1f)
        {
            isChanging = false;
            t = 0;

            if (cameraView == 1)
            {
                cameraView = 2;
            }
            else if (cameraView == 2 && movingDown)
            {
                cameraView = 1;
            }
            else if (cameraView == 2 && movingUp)
            {
                cameraView = 3;
            }
            else if (cameraView == 3)
            {
                cameraView = 2;
            }
        }

        trans.position = Vector3.Lerp(currentPos, nextPos, t);
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentSize, targetSize, t);
    }

    public int GetCameraView()
    {
        return cameraView;
    }
}
