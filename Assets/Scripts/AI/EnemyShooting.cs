using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int shootCooldown = 2;
    public float bulletSpeed = 4f;

    private GameObject player;
    private GameObject bulletInstance;
    private Rigidbody2D rb;

    private Vector3 playerPos;
    private Vector3 targetPos;
    private float shootTimer;
    private float angle;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        targetPos = (playerPos - transform.position).normalized;

        if (transform.position.x < playerPos.x)
            angle = Vector3.Angle(targetPos, Vector3.down);
        else
            angle = -Vector3.Angle(targetPos, Vector3.down);

        rb.MoveRotation(angle);
        shootTimer += Time.deltaTime;

        if (shootTimer > shootCooldown)
        {
            bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = targetPos * bulletSpeed;
            shootTimer = 0;
        }
    }
}
