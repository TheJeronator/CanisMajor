using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (gameObject.tag == "OPbullet")
            {
                GlobalsManager.Instance.playerHP -= 50;
                Destroy(gameObject);
            }
            if (gameObject.tag == "enemyEMP")
            {
                GlobalsManager.Instance.StartCoroutine("disableMoveAndShoot");
                GlobalsManager.Instance.Shields = 0;
                Destroy(gameObject);
            }
            else
            {
                if (GlobalsManager.Instance.shieldsDown == true)
                {
                    GlobalsManager.Instance.playerHP -= 10;
                    GlobalsManager.Instance.StartCoroutine("largeCooldown");
                    GlobalsManager.Instance.StopCoroutine("rechargeShields");
                    GlobalsManager.Instance.StopCoroutine("coolDown");
                    GlobalsManager.Instance.shieldIsRecharging = true;
                }
                else if (GlobalsManager.Instance.leftshieldEquipped == true && GlobalsManager.Instance.rightshieldEquipped == true && GlobalsManager.Instance.shieldsDown == false)
                {
                    GlobalsManager.Instance.Shields -= 10;
                    GlobalsManager.Instance.StartCoroutine("largeCooldown");
                    GlobalsManager.Instance.StopCoroutine("coolDown");
                    GlobalsManager.Instance.StopCoroutine("rechargeShields");
                    GlobalsManager.Instance.shieldIsRecharging = true;
                }
                else if (GlobalsManager.Instance.leftshieldEquipped == true || GlobalsManager.Instance.rightshieldEquipped == true && GlobalsManager.Instance.shieldsDown == false)
                {
                    GlobalsManager.Instance.Shields -= 20;
                    GlobalsManager.Instance.StartCoroutine("largeCooldown");
                    GlobalsManager.Instance.StopCoroutine("rechargeShields");
                    GlobalsManager.Instance.StopCoroutine("coolDown");
                    GlobalsManager.Instance.shieldIsRecharging = true;
                }
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
