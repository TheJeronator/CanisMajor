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
