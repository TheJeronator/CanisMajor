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
        if (GlobalsManager.Instance.mg1Equipped == true)
        {
            machineGun1.active = true;
        }
        if (GlobalsManager.Instance.mg2Equipped == true)
        {
           
        }
        if (GlobalsManager.Instance.shotgunEquipped == true)
        {
            
        }
        if (GlobalsManager.Instance.cannonEquipped == true)
        {
            
        }

        else if (GlobalsManager.Instance.mg1Equipped == false)
        {
           
        }
        else if (GlobalsManager.Instance.mg2Equipped == false)
        {
            
        }
        else if (GlobalsManager.Instance.shotgunEquipped == false)
        {
            
        }
        else if (GlobalsManager.Instance.cannonEquipped == false)
        {
           
        }
    }
}
