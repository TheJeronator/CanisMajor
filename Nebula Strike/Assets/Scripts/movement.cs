using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class movement : MonoBehaviour
{
    public float movementSpeed = 5;

    public Boundary boundary;

    public GameObject playerShot;
    public Transform shotSpawn1;
    public float fireRate;
    private float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > fireCooldown)
        {
            fireCooldown = Time.time + fireRate;
            shoot();
        }
    }
    // Update is called once per frame
    void shoot()
    {
        GameObject playerBullet = Instantiate(playerShot, shotSpawn1.position, shotSpawn1.rotation);
    }
    void FixedUpdate()
    {
        var playerBody = gameObject.GetComponent<Rigidbody2D>();

        float xmove = Input.GetAxis("Horizontal");
        float ymove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xmove, ymove, 0);
        playerBody.velocity = movement * movementSpeed;
        playerBody.position = new Vector3(
           Mathf.Clamp(playerBody.position.x, boundary.xMin, boundary.xMax),
           Mathf.Clamp(playerBody.position.y, boundary.yMin, boundary.yMax),
           Mathf.Clamp(playerBody.position.y, boundary.yMin, boundary.yMax)
       );
    }
}
