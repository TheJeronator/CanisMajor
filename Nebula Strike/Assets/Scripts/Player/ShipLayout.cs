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
            machineGun1.SetActive(true);
        }
        if (GlobalsManager.Instance.mg2Equipped == true)
        {
            machineGun2.SetActive(true);
        }
        if (GlobalsManager.Instance.shotgunEquipped == true)
        {
            shotGun.SetActive(true);
        }
        if (GlobalsManager.Instance.cannonEquipped == true)
        {
            Cannon.SetActive(true);
        }

        if (GlobalsManager.Instance.mg1Equipped == false)
        {
            machineGun1.SetActive(false);
        }
        if (GlobalsManager.Instance.mg2Equipped == false)
        {
            machineGun2.SetActive(false);
        }
        if (GlobalsManager.Instance.shotgunEquipped == false)
        {
            shotGun.SetActive(false);
        }
        if (GlobalsManager.Instance.cannonEquipped == false)
        {
            Cannon.SetActive(false);
        }
    }
}
