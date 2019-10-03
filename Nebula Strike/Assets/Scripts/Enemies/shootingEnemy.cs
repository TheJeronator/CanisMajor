using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : MonoBehaviour
{
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
        if (Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            shoot();
        }
    }
    void shoot()
    {
        GameObject playerBullet = Instantiate(enemyShot, shotSpawnEnemy1.position, shotSpawnEnemy1.rotation);
        Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shotSpawnEnemy1.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
