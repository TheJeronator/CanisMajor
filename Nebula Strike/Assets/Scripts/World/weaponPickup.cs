using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    public int Gunswitch;

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (Gunswitch)
        {
            case 1:
                GlobalsManager.Instance.mg1 = true;
                Destroy(gameObject);
                Debug.Log("mg1");
                break;
            case 2:
                GlobalsManager.Instance.mg2 = true;
                Destroy(gameObject);
                Debug.Log("mg2");
                break;
            case 3:
                GlobalsManager.Instance.shotgun = true;
                Destroy(gameObject);
                Debug.Log("shotgun");
                break;
            case 4:
                GlobalsManager.Instance.cannon = true;
                Destroy(gameObject);
                Debug.Log("cannon");
                break;
        }
        }
    }
