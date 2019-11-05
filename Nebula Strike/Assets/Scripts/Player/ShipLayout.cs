using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLayout : MonoBehaviour
{
    public GameObject machineGun1;
    public GameObject machineGun2;
    public GameObject Cloak;
    public GameObject shotGun;
    public GameObject Cannon;
    public GameObject shield1;
    public GameObject shield2;
    public GameObject tractorBeam;
    public GameObject shieldSprite;

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
        if (GlobalsManager.Instance.cloakEquipped == true)
        {
            Cloak.SetActive(true);
        }
        if (GlobalsManager.Instance.tractorbeamEquipped == true)
        {
            tractorBeam.SetActive(true);
        }
        if (GlobalsManager.Instance.leftshieldEquipped == true)
        {
            shield1.SetActive(true);
            if (GlobalsManager.Instance.Shields > 0)
            {
                GlobalsManager.Instance.shieldsDown = false;
            }
        }
        if (GlobalsManager.Instance.rightshieldEquipped == true)
        {
            shield2.SetActive(true);
            if (GlobalsManager.Instance.Shields > 0)
            {
                GlobalsManager.Instance.shieldsDown = false;
            }
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
        if (GlobalsManager.Instance.cloakEquipped == false)
        {
            Cloak.SetActive(false);
        }
        if (GlobalsManager.Instance.tractorbeamEquipped == false)
        {
            tractorBeam.SetActive(false);
        }
        if (GlobalsManager.Instance.leftshieldEquipped == false)
        {
            shield1.SetActive(false);
            if (GlobalsManager.Instance.rightshieldEquipped == false)
            {
                GlobalsManager.Instance.shieldsDown = true;
            }
        }
        if (GlobalsManager.Instance.rightshieldEquipped == false)
        {
            shield2.SetActive(false);
            if (GlobalsManager.Instance.leftshieldEquipped == false)
            {
                GlobalsManager.Instance.shieldsDown = true;
            }
        }
        if (GlobalsManager.Instance.cloakActive == true)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        }
        else if (GlobalsManager.Instance.cloakActive == false)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        if (GlobalsManager.Instance.leftshieldEquipped == true || GlobalsManager.Instance.rightshieldEquipped == true)
        {
            shieldSprite.SetActive(true);
        }
        else
        {
            shieldSprite.SetActive(false);
        }
    }

}
