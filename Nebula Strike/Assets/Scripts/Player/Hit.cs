using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
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
        if (collision.gameObject.tag == "enemy1")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "enemy2")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "enemy3")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "enemy4")
        {
            Destroy(gameObject);
        }
        else
        {
        Destroy(gameObject);
        }
        
    }
}
