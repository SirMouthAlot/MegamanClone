using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] GameObject player;
    Player playerProperties;

    float max = 28;

    // Start is called before the first frame update
    void Start()
    {
        playerProperties = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillAmount = (float)playerProperties.GetHealth() / (float)max;

        mask.fillAmount = fillAmount;
    }
}
