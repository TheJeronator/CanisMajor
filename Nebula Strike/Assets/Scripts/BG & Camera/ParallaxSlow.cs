using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSlow : MonoBehaviour
{
    float parallax = 4f;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mt = mr.material;
        Vector2 offset = mt.mainTextureOffset;
        offset.y = -transform.position.x / -transform.localScale.x / -parallax;
        offset.x = transform.position.y / transform.localScale.y / parallax;
        mt.mainTextureOffset = offset;
    }
}
