using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int shootCooldown = 2;
    public float bulletSpeed = 4f;

    public AngleSelector selector;

    private GameObject bulletInstance;

    private float shootTimer;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = selector.NormalizedVector();

        shootTimer += Time.deltaTime;

        if (shootTimer > shootCooldown)
        {
            bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = targetVector * bulletSpeed;
            shootTimer = 0;
        }
    }
}
