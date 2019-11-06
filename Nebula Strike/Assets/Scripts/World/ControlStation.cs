using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStation : MonoBehaviour
{
    private int hp = 1000;
    public GameObject perimeterTurret1;
    public GameObject perimeterTurret2;
    private void Update()
    {
        if (hp <= 0)
        {
            GlobalsManager.Instance.level1Completed = true;
            Destroy(gameObject);
            Destroy(perimeterTurret1);
            Destroy(perimeterTurret2);
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
