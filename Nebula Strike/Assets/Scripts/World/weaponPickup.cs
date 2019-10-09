using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mg1")
        {
            GlobalsManager.Instance.mg1 = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "mg2")
        {
            GlobalsManager.Instance.mg2 = true;
            Destroy(collision.gameObject);
        }
    }
}
