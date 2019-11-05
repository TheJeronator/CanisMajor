using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStation : MonoBehaviour
{
    private int hp = 1000;
    private void Update()
    {
        if (hp <= 0)
        {
            GlobalsManager.Instance.level1Completed = true;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerShot")
        {
            hp -= 25;
        }
        if (collision.gameObject.tag == "playerShotHeavy")
        {
            hp -= 100;
        }
    }
}
