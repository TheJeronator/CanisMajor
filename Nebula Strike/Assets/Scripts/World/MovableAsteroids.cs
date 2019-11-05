﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class MovableAsteroids : MonoBehaviour
{
    public Transform AsteroidSpot;
    Vector2 mousePos;
    private Rigidbody2D rb;
    public Camera cam;
    bool pickedup = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1) == true && GlobalsManager.Instance.tractorbeamEquipped == true && GlobalsManager.Instance.hasAsteroid == false)
        {
            grabAsteroid();
        }
    }

    public void grabAsteroid()
    {
            pickedup = true;
            GlobalsManager.Instance.hasAsteroid = true;
        Debug.Log("PickedUp");
    }
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1) == true && GlobalsManager.Instance.tractorbeamEquipped == true && GlobalsManager.Instance.hasAsteroid == true)
        {
            GlobalsManager.Instance.hasAsteroid = false;
            pickedup = false;
            Debug.Log("Done");
        }
        if (GlobalsManager.Instance.hasAsteroid == true && pickedup == true)
        {
            gameObject.transform.position = AsteroidSpot.position;
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
