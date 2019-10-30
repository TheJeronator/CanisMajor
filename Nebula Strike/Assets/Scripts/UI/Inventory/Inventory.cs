using System;
using System.Collections.Generic;
using UnityEngine;


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
                guns[0] = gunsList[0];
                Debug.Log(guns);
                Debug.Log(gunsList);
                refreshUI();
                GlobalsManager.Instance.mg1notYetAdded = false;
            }
        }
        if (GlobalsManager.Instance.mg2notYetAdded == true && GlobalsManager.Instance.mg2 == true)
        {
            {
                guns[1] = gunsList[1];
                Debug.Log(guns);
                Debug.Log(gunsList);
                refreshUI();
                GlobalsManager.Instance.mg2notYetAdded = false;
            }
        }
        if (GlobalsManager.Instance.shotgunnotYetAdded == true && GlobalsManager.Instance.shotgun == true)
        {
            {
                guns[2] = gunsList[2];
                Debug.Log(guns);
                Debug.Log(gunsList);
                refreshUI();
                GlobalsManager.Instance.shotgunnotYetAdded = false;
            }
        }
        if (GlobalsManager.Instance.cannonnotYetAdded == true && GlobalsManager.Instance.cannon == true)
        {
            {
                guns[3] = (gunsList[3]);
                Debug.Log(guns);
                Debug.Log(gunsList);
                refreshUI();
                GlobalsManager.Instance.cannonnotYetAdded = false;
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
