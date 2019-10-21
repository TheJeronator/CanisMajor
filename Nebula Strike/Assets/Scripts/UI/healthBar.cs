using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    Image healthbarSprite;
    public float maxHealth = 100;
    public static float HP;

    void Start()
    {
        healthbarSprite = GetComponent<Image>();
        HP = maxHealth;
    }

    void Update()
    {
         HP = GlobalsManager.Instance.playerHP;
    }

    private void FixedUpdate()
    {
        healthbarSprite.fillAmount = HP / maxHealth;
    }
}