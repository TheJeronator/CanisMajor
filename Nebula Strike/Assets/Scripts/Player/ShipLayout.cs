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
            
        }
        if (GlobalsManager.Instance.mg2 == true)
        {
           
        }
        if (GlobalsManager.Instance.shotgun == true)
        {
            
        }
        if (GlobalsManager.Instance.cannon == true)
        {
            
        }

        else if (GlobalsManager.Instance.mg1 == false)
        {
           
        }
        else if (GlobalsManager.Instance.mg2 == false)
        {
            
        }
        else if (GlobalsManager.Instance.shotgun == false)
        {
            
        }
        else if (GlobalsManager.Instance.cannon == false)
        {
           
        }
    }
}
