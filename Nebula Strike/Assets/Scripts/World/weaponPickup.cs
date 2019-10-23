using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    public int Gunswitch;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
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
                case 5:
                    GlobalsManager.Instance.cloak = true;
                    Destroy(gameObject);
                    Debug.Log("cloak");
                    break;
                case 6:
                    GlobalsManager.Instance.tractorBeam = true;
                    Destroy(gameObject);
                    Debug.Log("beam");
                    break;
                case 7:
                    GlobalsManager.Instance.leftShield = true;
                    Destroy(gameObject);
                    Debug.Log("leftshield");
                    break;
                case 8:
                    GlobalsManager.Instance.rightShield = true;
                    Destroy(gameObject);
                    Debug.Log("rightshield");
                    break;
            }
        }
    }
}
