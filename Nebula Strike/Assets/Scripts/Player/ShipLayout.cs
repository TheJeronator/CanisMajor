using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLayout : MonoBehaviour
{
    public GameObject machineGun1;
    public GameObject machineGun2;
   // public GameObject Cloak;
    public GameObject shotGun;
    public GameObject Cannon;
   // public GameObject shield1;
   // public GameObject shield2;
   // public GameObject tractorBeam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalsManager.Instance.mg1 == true)
        {
            machineGun1.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GlobalsManager.Instance.mg2 == true)
        {
            machineGun2.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GlobalsManager.Instance.shotgun == true)
        {
            shotGun.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (GlobalsManager.Instance.cannon == true)
        {
            Cannon.GetComponent<SpriteRenderer>().enabled = true;
        }

        else if (GlobalsManager.Instance.mg1 == false)
        {
            machineGun1.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (GlobalsManager.Instance.mg2 == false)
        {
            machineGun2.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (GlobalsManager.Instance.shotgun == false)
        {
            shotGun.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (GlobalsManager.Instance.cannon == false)
        {
            Cannon.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
