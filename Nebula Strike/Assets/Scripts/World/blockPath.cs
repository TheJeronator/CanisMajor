using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPath : MonoBehaviour
{
    public GameObject ship1;
    public GameObject ship2;
    public GameObject ship3;
    // Update is called once per frame
    void Update()
    {
        if (ship1 == null && ship2 == null && ship3 == null)
        {
            Destroy(gameObject);
        }
    }
}
