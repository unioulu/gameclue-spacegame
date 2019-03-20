using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public GameObject debris;

    public float speed = 0.8f;
    public int health = 3;

    private Rigidbody2D rb;
    private GameObject[] debris_instances = new GameObject[2];

    private float debrisSpread = 0.5f;
    private float debrisAngle = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5f) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 pos = transform.position;
        if (other.tag == "Bullet")
        {
            int dmg = other.gameObject.GetComponent<Bullet>().damage;
            health -= dmg;

            if (health <= 0)
            {
                debris_instances[0] = Instantiate(debris, new Vector3(pos.x + debrisSpread, pos.y, pos.z), Quaternion.identity);
                debris_instances[1] = Instantiate(debris, new Vector3(pos.x - debrisSpread, pos.y, pos.z), Quaternion.identity);

                debris_instances[0].GetComponent<Rigidbody2D>().velocity = new Vector3(debrisAngle, -speed, 0);
                debris_instances[1].GetComponent<Rigidbody2D>().velocity = new Vector3(-debrisAngle, -speed, 0);
              

                Destroy(gameObject);
            }

        }
    }
}
