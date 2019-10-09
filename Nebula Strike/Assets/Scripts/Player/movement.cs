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
    public Camera cam;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (GlobalsManager.Instance.playerHP == 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var playerRb = gameObject.GetComponent<Rigidbody2D>();

        float xmove = Input.GetAxis("Horizontal");
        float ymove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(xmove, ymove, 0);
        playerRb.velocity = movement * movementSpeed;
        playerRb.position = new Vector3(
           Mathf.Clamp(playerRb.position.x, boundary.xMin, boundary.xMax),
           Mathf.Clamp(playerRb.position.y, boundary.yMin, boundary.yMax),
           Mathf.Clamp(playerRb.position.y, boundary.yMin, boundary.yMax)
       );
        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        playerRb.rotation = angle;
    }
}
