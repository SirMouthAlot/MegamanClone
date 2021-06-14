using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthbar : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject cam;

    BossFrog bossProperties;
    CameraMovement camProperties;

    float max = 10;

    // Start is called before the first frame update
    void Start()
    {
        bossProperties = boss.GetComponent<BossFrog>();
        camProperties = cam.GetComponent<CameraMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (camProperties.GetCameraView() == 3)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

        float fillAmount = (float)bossProperties.GetHealth() / (float)max;

        mask.fillAmount = fillAmount;
    }
}
