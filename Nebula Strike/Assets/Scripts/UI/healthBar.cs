using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Text textbox;

    void Start()
    {
        textbox = GetComponent<Text>();
    }

    void Update()
    {
        textbox.text = "Health: " + GlobalsManager.Instance.playerHP;

        if (GlobalsManager.Instance.playerHP <= 0)
            Destroy(gameObject);
    }
}