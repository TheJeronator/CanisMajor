using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;


    public event Action<Gun> OnGunRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnGunRightClickedEvent;
        }
    }
    private void Update()
    {
        if (GlobalsManager.Instance.mg1 == true && GlobalsManager.Instance.mg2 == true && GlobalsManager.Instance.mg1Equipped == true)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (equipmentSlots[i].Gun != null)
                {
                    var mg = equipmentSlots[i].Gun;
                    if (mg.gunName == "singleMG")
                    {
                        equipmentSlots[i].Gun = null;
                        GlobalsManager.Instance.mg1Equipped = false;
                        GlobalsManager.Instance.mg1Unequipped = true;
                    }
                }
            }
        }
    }
    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }
    public bool AddGun(EquippableGun gun, out EquippableGun previousGun)
    {
        for (int i = 0; i< equipmentSlots.Length; i++)
        {
            if (!equipmentSlots[i].Gun == gun)
            {
                previousGun = (EquippableGun)equipmentSlots[i].Gun;
                equipmentSlots[i].Gun = gun;
                return true;
            }
        }
        previousGun = null;
        return false;
    }

    public bool RemoveGun(EquippableGun gun)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Gun == gun)
            {
                equipmentSlots[i].Gun = null;
                return true;
            }
        }
        return false;
    }
}
