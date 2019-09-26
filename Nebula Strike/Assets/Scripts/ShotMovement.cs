using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * speed;
    }
}
