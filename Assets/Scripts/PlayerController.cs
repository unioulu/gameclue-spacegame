﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject FPSLogger;

    public float speed = 0.1f;
    private Vector3 lastPos;
    readonly float boundary_left = -10f;
    readonly float boundary_right = 10f;
    readonly float boundary_top = 4f;
    readonly float boundary_bottom = -4f;

    readonly KeyCode SHOOT = KeyCode.Space;
    readonly List<KeyCode> MOVE_LEFT = new List<KeyCode>(){KeyCode.LeftArrow, KeyCode.J};
    readonly List<KeyCode> MOVE_RIGHT = new List<KeyCode>(){KeyCode.RightArrow, KeyCode.L};
    readonly List<KeyCode> MOVE_UP = new List<KeyCode>(){KeyCode.UpArrow, KeyCode.I};
    readonly List<KeyCode> MOVE_DOWN = new List<KeyCode>(){KeyCode.DownArrow, KeyCode.K};


    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (keysPressed(MOVE_LEFT) && (pos.x + speed) > boundary_left) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, 0);
        }

        if (keysPressed(MOVE_RIGHT) && (pos.x + speed) < boundary_right) {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0);
        }

        //pos = transform.position;

        if (keysPressed(MOVE_UP) && (pos.y + speed) < boundary_top) {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0); 
        }

        if (keysPressed(MOVE_DOWN) && (pos.y + speed) > boundary_bottom) {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
        }

        if (Input.GetKeyDown(SHOOT))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        
        lastPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
            FpsLogger fl = FPSLogger.GetComponent<FpsLogger>();
            fl.FpsToFile();
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
