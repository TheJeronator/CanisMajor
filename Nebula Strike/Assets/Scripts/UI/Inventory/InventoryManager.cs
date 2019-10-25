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
            switch (gun.gunName)
            {
                case "singleMG":
                    if (GlobalsManager.Instance.mg2Equipped == false)
                    {
                        GlobalsManager.Instance.mg1Equipped = false;
                    }
                    break;
                case "doubleMG":
                    GlobalsManager.Instance.mg1Equipped = false;
                    GlobalsManager.Instance.mg2Equipped = false;
                    break;
                case "shotGun":
                    GlobalsManager.Instance.shotgunEquipped = false;
                    break;
                case "cannon":
                    GlobalsManager.Instance.cannonEquipped = false;
                    break;
            }
        }
    }
    public void Equip(EquippableGun gun)
{
    if (inventory.RemoveGun(gun))
    {
        EquippableGun previousGun;
        if (HotBar.AddGun(gun, out previousGun))
            {
                switch (gun.gunName)
                {
                    case "singleMG":
                        GlobalsManager.Instance.mg1Equipped = true;
                        break;
                    case "doubleMG":
                        GlobalsManager.Instance.mg1Equipped = true;
                        GlobalsManager.Instance.mg2Equipped = true;
                        break;
                    case "shotGun":
                        GlobalsManager.Instance.shotgunEquipped = true;
                        break;
                    case "cannon":
                        GlobalsManager.Instance.cannonEquipped = true;
                        break;
                }
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
