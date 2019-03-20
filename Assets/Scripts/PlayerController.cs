using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 0.1f;

    private Rigidbody2D rb;
    private Vector3 lastPos;
    private float boundary_left = -10f;
    private float boundary_right = 10f;
    private float boundary_top = 4f;
    private float boundary_bottom = -4f;

    private KeyCode SHOOT = KeyCode.Space;
    private List<KeyCode> MOVE_LEFT = new List<KeyCode>(){KeyCode.LeftArrow, KeyCode.J};
    private List<KeyCode> MOVE_RIGHT = new List<KeyCode>(){KeyCode.RightArrow, KeyCode.L};
    private List<KeyCode> MOVE_UP = new List<KeyCode>(){KeyCode.UpArrow, KeyCode.I};
    private List<KeyCode> MOVE_DOWN = new List<KeyCode>(){KeyCode.DownArrow, KeyCode.K};


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 dirVector = Vector3.zero;
        if (keysPressed(MOVE_LEFT) && pos.x > boundary_left) { dirVector.x = -1; }

        if (keysPressed(MOVE_RIGHT) && pos.x < boundary_right) { dirVector.x = 1; }

        if (keysPressed(MOVE_UP) && pos.y < boundary_top) { dirVector.y = 1; }

        if (keysPressed(MOVE_DOWN) && pos.y > boundary_bottom) { dirVector.y = -1; }

        if (Input.GetKeyUp(SHOOT)) { Instantiate(bullet, transform.position, Quaternion.identity); }

        rb.velocity = dirVector.normalized * speed;
        dirVector = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private bool keysPressed(List<KeyCode> keycodes) {
        foreach (var keycode in keycodes)
        {
            if (Input.GetKey(keycode)) {
                return true;
            }
        }
        return false;
    }

    private bool keysPressed(KeyCode keycode) {
        if (Input.GetKey(keycode)) {
            return true;
        } else {
            return false;
        }
    }
}
