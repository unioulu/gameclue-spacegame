using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

    public float speed = 0.1f;

    private Vector3 lastPos;
    private float boundary_left = -10f;
    private float boundary_right = 10f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x > boundary_left) { transform.position = new Vector3(lastPos.x + speed, transform.position.y, 0); }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x < boundary_right) { transform.position = new Vector3(lastPos.x - speed, transform.position.y, 0); }
        lastPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
