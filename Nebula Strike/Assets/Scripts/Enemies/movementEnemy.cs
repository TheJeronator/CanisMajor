using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEnemy : MonoBehaviour
{
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
           
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    void FixedUpdate()
    {
        var enemyRb = GetComponent<Rigidbody2D>();

        Vector2 lookDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        enemyRb.rotation = angle;
    }
}
