using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    private int hp = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerShot")
        {
            hp -= 25;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "playerShotHeavy")
        {
            hp -= 100;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
