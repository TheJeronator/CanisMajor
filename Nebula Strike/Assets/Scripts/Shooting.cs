using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public GameObject playerShot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public float fireRate;
    private float fireCooldown;
    public float bulletSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            shoot();
        }
    }
    void shoot()
    {
       GameObject playerBullet = Instantiate(playerShot, shotSpawn1.position, shotSpawn1.rotation);
       Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
       bulletRb.AddForce(shotSpawn1.up * bulletSpeed, ForceMode2D.Impulse);
       //
       //
        GameObject playerBullet2 = Instantiate(playerShot, shotSpawn2.position, shotSpawn2.rotation);
        Rigidbody2D bulletRb2 = playerBullet2.GetComponent<Rigidbody2D>();
        bulletRb2.AddForce(shotSpawn2.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
