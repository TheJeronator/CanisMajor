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
            GlobalsManager.Instance.playerHP -= 20;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
