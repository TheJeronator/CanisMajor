using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var trans = 0.5f;
        var col = gameObject.GetComponent<Renderer>().material.color;
        col.a = trans;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
