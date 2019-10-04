using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLayout : MonoBehaviour
{
    public Sprite machineGun1;
    public Sprite machineGun2;
    public Sprite Cloak;
    public Sprite Shotgun;
    public Sprite Cannon;
    public Sprite shield1;
    public Sprite shield2;
    public Sprite tractorBeam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var sprite = GetComponent<SpriteRenderer>();

        if (GlobalsManager.Instance.mg1 == true)
        {
            sprite.sprite = machineGun1;
        }
        if (GlobalsManager.Instance.mg2 == true)
        {
            sprite.sprite = machineGun2;
        }
    }
}
