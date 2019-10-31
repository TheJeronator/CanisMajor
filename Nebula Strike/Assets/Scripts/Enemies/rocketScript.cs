using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float rotationSpeed = 200f;
    private Rigidbody2D rb;

    public void Awake()
    {
        target = GameObject.FindWithTag("player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        Vector2 lookDir = target.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
