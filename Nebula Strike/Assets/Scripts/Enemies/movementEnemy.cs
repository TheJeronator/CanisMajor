using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class movementEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float movementSpeed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        var pathDest = GetComponent<AIDestinationSetter>();
        pathDest.target = null;
        if (GlobalsManager.Instance.playerHP == 0)
        {
            Destroy(this);
        }
        if (Vector3.Distance(transform.position, target.position) < GlobalsManager.Instance.spottingrange)
        {
            pathDest.target = target;
        }
    }

}
