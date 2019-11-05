using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject playerShot;
    public GameObject cannonShot;
    public Transform shotSpawnMGLeft;
    public Transform shotSpawnMGRight;
    public Transform shotSpawnShotgun1;
    public Transform shotSpawnShotgun2;
    public Transform shotSpawnShotgun3;
    public Transform shotSpawnCannon;
    public AudioSource[] shotsound;
    public float fireRate;
    public float heavyFirerate;
    private float fireCooldown;
    private float heavyFirecooldown;
    public float bulletSpeed = 20f;
    public float cannonBulletspeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shotsound = GetComponents<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            shoot();
        }
        if (Input.GetButton("Fire1") && Time.time > heavyFirecooldown)
        {
            heavyFirecooldown = Time.time + heavyFirerate;
            shootHeavy();
        }
    }
    private void shoot()
    {
        if (GlobalsManager.Instance.mg1Equipped == true)
        {
            shotsound[0].Play();
            GameObject playerBullet2 = Instantiate(playerShot, shotSpawnMGLeft.position, shotSpawnMGLeft.rotation);
            Rigidbody2D bulletRb2 = playerBullet2.GetComponent<Rigidbody2D>();
            bulletRb2.AddForce(shotSpawnMGLeft.up * bulletSpeed, ForceMode2D.Impulse);
        }
        if (GlobalsManager.Instance.mg2Equipped == true)
        {
            shotsound[0].Play();
            GameObject playerBullet = Instantiate(playerShot, shotSpawnMGRight.position, shotSpawnMGRight.rotation);
            Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shotSpawnMGRight.up * bulletSpeed, ForceMode2D.Impulse);
        }
        if (GlobalsManager.Instance.shotgunEquipped == true)
        {
            shotsound[0].Play();
            GameObject playerBullet = Instantiate(playerShot, shotSpawnShotgun1.position, shotSpawnShotgun1.rotation);
            Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shotSpawnShotgun1.up * bulletSpeed, ForceMode2D.Impulse);
            GameObject playerBullet2 = Instantiate(playerShot, shotSpawnShotgun2.position, shotSpawnShotgun2.rotation);
            Rigidbody2D bulletRb2 = playerBullet2.GetComponent<Rigidbody2D>();
            bulletRb2.AddForce(shotSpawnShotgun2.up * bulletSpeed, ForceMode2D.Impulse);
            GameObject playerBullet3 = Instantiate(playerShot, shotSpawnShotgun3.position, shotSpawnShotgun3.rotation);
            Rigidbody2D bulletRb3 = playerBullet3.GetComponent<Rigidbody2D>();
            bulletRb3.AddForce(shotSpawnShotgun3.up * bulletSpeed, ForceMode2D.Impulse);
        }

    }
    private void shootHeavy()
    {
        if (GlobalsManager.Instance.cannonEquipped == true)
        {
            shotsound[1].Play();
            GameObject playerBullet = Instantiate(cannonShot, shotSpawnShotgun2.position, shotSpawnShotgun2.rotation);
            Rigidbody2D bulletRb = playerBullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shotSpawnShotgun2.up * cannonBulletspeed, ForceMode2D.Impulse);
        }
    }
}
