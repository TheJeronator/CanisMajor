using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{

    public float interval = 5.0f;
    private float timestamp = .0f;

    void Start()
    {
        timestamp = Time.time + 2;
    }

    void Update()
    {
        if (interval < Time.time - timestamp)
        {
            Destroy(gameObject);  // destroy the bullet after {interval} seconds
            Debug.Log("Destroyed");
        }
    }
}