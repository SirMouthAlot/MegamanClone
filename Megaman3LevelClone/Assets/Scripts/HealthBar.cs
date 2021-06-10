using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject player;

    Player playerProperties;

    // Start is called before the first frame update
    void Start()
    {
        playerProperties = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = playerProperties.GetHealth();
    }
}
