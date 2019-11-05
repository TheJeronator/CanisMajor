using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    private int hp = 100;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerShot")
        {
            hp -= 25;
            StartCoroutine("enemyDamaged");
            if (hp <= 0)
            {
                Explode();
            }
        }
        if (collision.gameObject.tag == "playerShotHeavy")
        {
            hp -= 100;
            StartCoroutine("enemyDamaged");
            if (hp <= 0)
            {
                Explode();
            }
        }
    }
    void Explode()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(exp, 6f);
        Destroy(gameObject);
    }
    IEnumerator enemyDamaged()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponentInChildren<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    }
}
