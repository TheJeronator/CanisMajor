using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : gunSlot
{
    public WeaponNum WeaponNum;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = WeaponNum.ToString() + " Slot";
    }
}
