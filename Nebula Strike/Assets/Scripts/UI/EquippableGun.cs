using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponNum
{
    Weapon1,
    Weapon2, 
    Weapon3,
}
[CreateAssetMenu]
public class EquippableGun : Gun
{
    public WeaponNum WeaponNum;
}

