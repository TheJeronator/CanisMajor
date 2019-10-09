using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float movementSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (Vector3.Distance(transform.position, target.position) > 8f)
            {
                transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
            }
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
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        enemyRb.rotation = angle;
    }
}
