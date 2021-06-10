using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField] int contactDamage;

    public int GetContactDamage()
    {
        return contactDamage;
    }
}
