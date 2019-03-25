using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{

    public GameObject bulletPrefab;

    public KeyCode shootKey = KeyCode.Space;

    public float maxKeyHoldTime = 1f;

    private float keyHoldTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(shootKey))
        {
            keyHoldTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(shootKey))
        {
            if (keyHoldTime < maxKeyHoldTime)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
            keyHoldTime = 0f;
        }

    }
}
