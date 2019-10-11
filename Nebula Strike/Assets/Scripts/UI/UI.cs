using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image singleMG;
    public Image doubleMG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalsManager.Instance.mg1 == true && GlobalsManager.Instance.mg2 == false || GlobalsManager.Instance.mg2 == true && GlobalsManager.Instance.mg1 == false)
        {
            singleMG.enabled = true;
            doubleMG.enabled = false;
        }
        else if (GlobalsManager.Instance.mg1 == true && GlobalsManager.Instance.mg2 == true)
        {
            doubleMG.enabled = true;
            singleMG.enabled = false;
        }
    }
}
