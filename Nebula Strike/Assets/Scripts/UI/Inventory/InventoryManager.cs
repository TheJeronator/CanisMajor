using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ 
    [SerializeField] Inventory inventory;
    [SerializeField] HotBar HotBar;


    private void Awake()
    {
        inventory.OnGunRightClickedEvent += EquipFromInventory;
        HotBar.OnGunRightClickedEvent += UnequipFromHotbar;
    }

    private void EquipFromInventory (Gun gun)
    {
        if (gun is EquippableGun)
        {
            Equip((EquippableGun)gun);
        }
    }

    private void UnequipFromHotbar(Gun gun)
    {
        if (gun is EquippableGun)
        {
            Unequip((EquippableGun)gun);
        }
    }
    public void Equip(EquippableGun gun)
{
    if (inventory.RemoveGun(gun))
    {
        EquippableGun previousGun;
        if (HotBar.AddGun(gun, out previousGun))
            {
                if (previousGun != null)
                {
                    inventory.AddGun(previousGun);
                }
            }
        else
            {
                inventory.AddGun(gun);
            }
    }
}
    public void Unequip(EquippableGun gun)
    {
        if (!inventory.IsFull() && HotBar.RemoveGun(gun))
        {
            inventory.AddGun(gun);
        }
    }
}
