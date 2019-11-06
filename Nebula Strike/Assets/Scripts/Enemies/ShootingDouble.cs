using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDouble : MonoBehaviour
{
    public Transform player;
    public GameObject enemyShot;
    public Transform shotSpawnEnemy1;
    public Transform shotSpawnEnemy2;
    public float fireRate;
    private float fireCooldown;
    public float bulletSpeed = 10f;
    public AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GlobalsManager.Instance.playerHP <= 0)
        {
            Destroy(this);
        }
        if (Time.time > fireCooldown && (Vector3.Distance(transform.position, player.position) < GlobalsManager.Instance.spottingrange))
        {
            fireCooldown = Time.time + fireRate;
            shoot();
        }
    }
    void shoot()
    {
        shotSound.Play();
        GameObject playerBullet = Instantiate(enemyShot, shotSpawnEnemy1.position, shotSpawnEnemy1.rotation);
        GameObject playerBullet2 = Instantiate(enemyShot, shotSpawnEnemy2.position, shotSpawnEnemy2.rotation);
        Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletRb2 = playerBullet2.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        bulletRb2.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
