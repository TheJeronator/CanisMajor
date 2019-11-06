using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public GameObject ShieldsSprite;
    Image healthbarSprite;
    public float maxHealth = 100;
    public static float HP;
    public float maxShield = 100;
    public static float Shield;
    public Image Shieldspritefill;
    public static float weaponHeat;
    public float maxHeat = 100;
    public Image heatBar;

    void Start()
    {
        healthbarSprite = GetComponent<Image>();
        HP = maxHealth;
        Shield = maxShield;
    }

    void Update()
    {
        if (GlobalsManager.Instance.leftshieldEquipped == true || GlobalsManager.Instance.rightshieldEquipped == true)
        {
            ShieldsSprite.SetActive(true);
            Shield = GlobalsManager.Instance.Shields;
        }
        else
        {
            ShieldsSprite.SetActive(false);
        }
         HP = GlobalsManager.Instance.playerHP;
        weaponHeat = GlobalsManager.Instance.weaponHeat;
    }

    private void FixedUpdate()
    {
        healthbarSprite.fillAmount = HP / maxHealth;
        Shieldspritefill.fillAmount = Shield / maxShield;
        heatBar.fillAmount = weaponHeat / maxHeat;
    }
}