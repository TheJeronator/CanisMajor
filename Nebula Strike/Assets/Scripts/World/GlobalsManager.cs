﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsManager : MonoBehaviour
{
    public static GlobalsManager Instance { get; private set; }

    public int playerHP = 100;
    public bool mg1 = false;
    public bool mg2 = false;
    public bool shotgun = false;
    public bool cannon = false;
    public bool shields = false;
        // NEED TO ADD BOOLS FOR OTHER GUNS

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
}
