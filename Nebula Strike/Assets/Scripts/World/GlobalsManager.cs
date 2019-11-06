using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalsManager : MonoBehaviour
{
    public static GlobalsManager Instance { get; private set; }

    public GameObject Inventory;
    public int playerHP = 100;
    public int Shields = 100;
    public float spottingrange = 30f;
    public float sniperRange = 40f;
    public movement playerMovement;
    public Shooting playerShooting;
    public Rigidbody2D playerRB;
    public GameObject gameMenu;

    public bool level1Completed = false;
    public bool level2Completed = false;
    

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
    public bool cloaknotYetAdded = true;
    public bool leftshieldnotYetAdded = true;
    public bool rightshieldnotYetAdded = true;
    public bool tractorbeamnotYetAdded = true;

    public bool mg1Equipped = false;
    public bool mg1Unequipped = false;
    public bool mg2Equipped = false;
    public bool shotgunEquipped = false;
    public bool cannonEquipped = false;
    public bool cloakEquipped = false;
    public bool leftshieldEquipped = false;
    public bool rightshieldEquipped = false;
    public bool tractorbeamEquipped = false;

    public bool cloakActive = false;
    public float cloakCooldown;
    public bool hasAsteroid = false;
    public bool shieldsDown = true;
    public bool shieldIsRecharging = false;
    public float weaponHeat;
    public bool weaponsOverheated = false;
    public bool weaponsCooling = false;
    public bool tut1Complete = false;

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
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        Inventory.SetActive(false);
        gameMenu.SetActive(false);
        StartCoroutine("coolWeapons");
    }
    IEnumerator disableMoveAndShoot()
    {
        playerMovement.enabled = false;
        playerShooting.enabled = false;
        playerRB.velocity = Vector2.zero;

        yield return new WaitForSeconds(1.5f);

        playerShooting.enabled = true;
        playerMovement.enabled = true;
    }
    IEnumerator CloakActivated()
    {

        GlobalsManager.Instance.cloakActive = true;

        yield return new WaitForSeconds(7f);

        GlobalsManager.Instance.cloakActive = false;
        GlobalsManager.Instance.cloakCooldown = Time.time + 10f;
    }
    IEnumerator rechargeShields()
    {

        yield return new WaitForSeconds(0.4f);
        if (GlobalsManager.Instance.Shields < 100)
        {
            GlobalsManager.Instance.Shields += 10;
            StartCoroutine("rechargeShields");
        }
        else
        {
            GlobalsManager.Instance.shieldsDown = false;
            GlobalsManager.Instance.shieldIsRecharging = false;
        }
    }
    IEnumerator largeCooldown()
    {
        yield return new WaitForSeconds(12f);
        StartCoroutine("rechargeShields");
        GlobalsManager.Instance.shieldIsRecharging = true;
    }
    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(7f);
        StartCoroutine("rechargeShields");
        GlobalsManager.Instance.shieldIsRecharging = true;
    }
    IEnumerator weaponsCooldown()
    {
        weaponsCooling = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine("coolWeapons");
    }
    IEnumerator coolWeapons()
    {
        if (GlobalsManager.Instance.weaponHeat > 0 && weaponsOverheated == false)
        {
            GlobalsManager.Instance.weaponHeat -= 1;
        } else if (GlobalsManager.Instance.weaponsOverheated == true)
        {
            GlobalsManager.Instance.StartCoroutine("overheatedCool");   
        }
        yield return new WaitForSeconds(0.15f);
        if (GlobalsManager.Instance.weaponsOverheated == false)
        {
            GlobalsManager.Instance.StartCoroutine("coolWeapons");
        }
    }
    IEnumerator overheatedCool()
    {
        GlobalsManager.Instance.weaponHeat -= 1;
        yield return new WaitForSeconds(0.03f);
        if (GlobalsManager.Instance.weaponHeat <= 30)
        {
            GlobalsManager.Instance.weaponsOverheated = false;
            GlobalsManager.Instance.weaponsCooling = false;
            StopCoroutine("overheatedCool");
            StartCoroutine("coolWeapons");
        } else
        {
            StartCoroutine("overheatedCool");
        }
    }
    public void Update()
    {
        if (gameMenu.activeSelf)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            Inventory.SetActive(!Inventory.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
        }
        if (GlobalsManager.Instance.cloakActive == true)
        {
            GlobalsManager.Instance.spottingrange = 10f;
            GlobalsManager.Instance.sniperRange = 15f;
        }
        else
        {
            GlobalsManager.Instance.spottingrange = 35f;
            GlobalsManager.Instance.sniperRange = 40f;
        }
        if (GlobalsManager.Instance.Shields <= 0)
        {
            if (GlobalsManager.Instance.shieldIsRecharging == false)
            {
                StartCoroutine("coolDown");
                GlobalsManager.Instance.shieldIsRecharging = true;
            }
            GlobalsManager.Instance.shieldsDown = true;
        }
        if (GlobalsManager.Instance.weaponHeat >= 100 && weaponsCooling == false)
        {
            GlobalsManager.Instance.weaponsOverheated = true;
            GlobalsManager.Instance.StopCoroutine("coolWeapons");
            GlobalsManager.Instance.StartCoroutine("weaponsCooldown");
        } 
    }
    private void LateUpdate()
    {
        if (playerHP <= 0)
        {
            SceneManager.LoadScene(6);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            playerHP = 1000;
        }
    }
}
