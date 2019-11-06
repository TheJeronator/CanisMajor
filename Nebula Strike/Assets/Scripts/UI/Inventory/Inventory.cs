using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [SerializeField] List<Gun> guns;
    [SerializeField] Transform gunsParent;
    [SerializeField] gunSlot[] gunSlots;

    [SerializeField] List<Gun> gunsList;

    public event Action<Gun> OnGunRightClickedEvent;

    private void Update()
    {

        if (GlobalsManager.Instance.mg1notYetAdded == true && GlobalsManager.Instance.mg1 == true)
        {
            {
                for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
                {
                    if (guns[i] == null)
                    {
                        guns[i] = gunsList[0];
                        refreshUI();
                        GlobalsManager.Instance.mg1notYetAdded = false;
                        break;
                    }
                }
            }
        }
        if (GlobalsManager.Instance.mg2notYetAdded == true && GlobalsManager.Instance.mg2 == true)
        {
            {
                for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
                {
                    if (guns[i] == null)
                    {
                        guns[i] = gunsList[1];
                        refreshUI();
                        GlobalsManager.Instance.mg2notYetAdded = false;
                        break;
                    }
                }
            }
        }
        if (GlobalsManager.Instance.shotgunnotYetAdded == true && GlobalsManager.Instance.shotgun == true)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] == null)
                {
                    guns[i] = gunsList[2];
                    refreshUI();
                    GlobalsManager.Instance.shotgunnotYetAdded = false;
                    break;
                }
            }
        }
        if (GlobalsManager.Instance.cannonnotYetAdded == true && GlobalsManager.Instance.cannon == true)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] == null)
                {
                    guns[i] = gunsList[3];
                    refreshUI();
                    GlobalsManager.Instance.cannonnotYetAdded = false;
                    break;
                }
            }
        }
        if (GlobalsManager.Instance.cloaknotYetAdded == true && GlobalsManager.Instance.cloak == true)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] == null)
                {
                    guns[i] = gunsList[4];
                    refreshUI();
                    GlobalsManager.Instance.cloaknotYetAdded = false;
                    break;
                }
            }
        }
        if (GlobalsManager.Instance.tractorbeamnotYetAdded == true && GlobalsManager.Instance.tractorBeam == true)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] == null)
                {
                    guns[i] = gunsList[5];
                    refreshUI();
                    GlobalsManager.Instance.tractorbeamnotYetAdded = false;
                    break;
                }
            }
        }
        if (GlobalsManager.Instance.leftshieldnotYetAdded == true && GlobalsManager.Instance.leftShield == true)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] == null)
                {
                    guns[i] = gunsList[6];
                    refreshUI();
                    GlobalsManager.Instance.leftshieldnotYetAdded = false;
                    break;
                }
            }
        }
        if (GlobalsManager.Instance.rightshieldnotYetAdded == true && GlobalsManager.Instance.rightShield == true)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] == null)
                {
                    guns[i] = gunsList[7];
                    refreshUI();
                    GlobalsManager.Instance.rightshieldnotYetAdded = false;
                    break;
                }
            }
        }
        if (GlobalsManager.Instance.mg1 == true && GlobalsManager.Instance.mg2 == true && GlobalsManager.Instance.mg1Equipped == false)
        {
            for (int i = 0; i < guns.Count && i < gunSlots.Length; i++)
            {
                if (guns[i] != null)
                {
                    var mg = guns[i];
                    Debug.Log(mg);
                    if (mg.gunName == "singleMG")
                    {
                        RemoveGun(mg);
                        GlobalsManager.Instance.mg1 = false;
                        break;
                    }
                }
            }
        }

    }
    private void Awake()
    {

        for (int i = 0; i < gunSlots.Length; i++)
        {
            gunSlots[i].OnRightClickEvent += OnGunRightClickedEvent;
        }
    }

    private void OnValidate()
    {
       
        if (gunsParent != null)
            gunSlots = gunsParent.GetComponentsInChildren<gunSlot>();

        refreshUI();
    }

    private void refreshUI()
    {
        int i = 0;
        for (; i < guns.Count && i < gunSlots.Length; i++)
        {
            gunSlots[i].Gun = guns[i];
        }

        for (; i < gunSlots.Length; i++)
        {
            gunSlots[i].Gun = null;
        }
    }

    public bool AddGun (Gun gun)
    {
        if (IsFull())
            return false;

        guns.Add(gun);
        refreshUI();
        return true;
    }

    public bool RemoveGun(Gun gun)
    {
        if (guns.Remove(gun))
        {
            refreshUI();
            return true;
            
        }
        return false;
    }

    public bool IsFull()
    {
        return guns.Count >= gunSlots.Length;
    }
    
}
