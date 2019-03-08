using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

    public float speed = 0.1f;

    private Vector3 lastPos;
    private float boundary_left = -10f;
    private float boundary_right = 10f;
    private float boundary_top = 4f;
    private float boundary_bottom = -4f;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow) && (pos.x + speed) < boundary_right) { transform.position = new Vector3(lastPos.x + speed, pos.y, 0); }
        if (Input.GetKey(KeyCode.LeftArrow) && (pos.x + speed) > boundary_left) { transform.position = new Vector3(lastPos.x - speed, pos.y, 0); }
        pos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow) && (pos.y + speed) < boundary_top) { transform.position = new Vector3(pos.x, lastPos.y + speed, 0); }
        if (Input.GetKey(KeyCode.DownArrow) && (pos.y + speed) > boundary_bottom) { transform.position = new Vector3(pos.x, lastPos.y - speed, 0); }
        lastPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.name == "Asteroid(Clone)" || other.name == "Debris(Clone)") 
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
