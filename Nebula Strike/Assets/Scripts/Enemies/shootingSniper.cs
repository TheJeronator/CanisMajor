﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSniper : MonoBehaviour
{
    public Transform player;
    public GameObject enemyShot;
    public Transform shotSpawnEnemy1;
    public float fireRate;
    private float fireCooldown;
    public float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Time.time > fireCooldown && (Vector3.Distance(transform.position, player.position) < GlobalsManager.Instance.sniperRange))
        {
            fireCooldown = Time.time + fireRate;
            shoot();
        }
    }
    void shoot()
    {
        GameObject playerBullet = Instantiate(enemyShot, shotSpawnEnemy1.position, shotSpawnEnemy1.rotation);
        Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        bulletRb.rotation = angle;
        bulletRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}