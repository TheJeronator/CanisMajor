using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class movementEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    private ParticleSystem[] particles;
    private Rigidbody2D rb;
    private Vector3 position;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        var pathDest = GetComponent<AIDestinationSetter>();
        pathDest.target = null;
        position = transform.position;
        if (GlobalsManager.Instance.playerHP == 0)
        {
            Destroy(this);
        }
        if (Vector3.Distance(transform.position, target.position) <= 10f)
        {
            pathDest.target = transform;
            transform.up = target.position - transform.position;
        }
        else if (gameObject.tag == "enemy3")
        {
            if (Vector3.Distance(transform.position, target.position) < GlobalsManager.Instance.sniperRange && Vector3.Distance(transform.position, target.position) > 10f)
            {
                pathDest.target = target;
            }
        }
        else if (Vector3.Distance(transform.position, target.position) < GlobalsManager.Instance.spottingrange && Vector3.Distance(transform.position, target.position) > 10f)
        {
            pathDest.target = target;
        }
        if (position != newPosition)
        {
            foreach (ParticleSystem particle in particles)
            {
                particle.Play();
                particle.enableEmission = true;
            }
        }
        else
        {
            foreach (ParticleSystem particle in particles)
            {
                particle.Stop();
                particle.enableEmission = false;
            }
        }
        newPosition = position;
    }

}
