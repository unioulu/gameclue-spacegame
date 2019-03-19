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

    private float shootTimer;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if(shootTimer > shootCooldown)
        {
            playerPos = player.transform.position;
            Vector3 targetPos = (playerPos - transform.position).normalized;
            bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = targetPos * bulletSpeed;
            shootTimer = 0;
        }
    }
}
