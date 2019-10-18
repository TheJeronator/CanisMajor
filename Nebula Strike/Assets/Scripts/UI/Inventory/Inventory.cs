using System;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] List<Gun> guns;
    [SerializeField] Transform gunsParent;
    [SerializeField] gunSlot[] gunSlots;

    public event Action<Gun> OnGunRightClickedEvent;

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
