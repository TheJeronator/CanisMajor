﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsManager : MonoBehaviour
{
    public static GlobalsManager Instance { get; private set; }

    public GameObject Inventory;
    public int playerHP = 100;
    public bool mg1 = false;
    public bool mg2 = false;
    public bool shotgun = false;
    public bool cannon = false;
    public bool cloak = false;
    public bool leftShield = false;
    public bool rightShield = false;
    public bool tractorBeam = false;

    public bool mg1notYetAdded = true;
    public bool mg2notYetAdded = true;
    public bool shotgunnotYetAdded = true;
    public bool cannonnotYetAdded = true;

    public bool mg1Equipped = false;
    public bool mg2Equipped = false;
    public bool shotgunEquipped = false;
    public bool cannonEquipped = false;

    public enum guns
    {
        singleMG = 0,
        doubleMG = 1,
        shotgun = 2,
        cannon = 3,
        cloakingDevice = 4,
        singleShield = 5,
        doubleShield = 6,
        tractorBeam = 7,
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        Inventory.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}
