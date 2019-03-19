using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, speed, 0);

        if (transform.position.y > 5f) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy") { Destroy(gameObject); }

    }
}
