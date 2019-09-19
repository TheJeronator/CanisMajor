using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xmove = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var ymove = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        transform.Translate(xmove, ymove, 0);
    }
}
