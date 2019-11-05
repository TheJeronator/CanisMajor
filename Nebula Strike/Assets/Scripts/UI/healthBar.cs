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
    }

    private void FixedUpdate()
    {
        healthbarSprite.fillAmount = HP / maxHealth;
        Shieldspritefill.fillAmount = Shield / maxShield;
    }
}