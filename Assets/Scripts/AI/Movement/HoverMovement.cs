using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour {

    public Vector3 hoverPosition = Vector3.zero;

    [SerializeField]
    private Rigidbody2D rb;

    public float rotationSpeed = 10f;
    public float speed = 0.8f;

    // Start is called before the first frame update
    void Start() {
        rb.velocity = new Vector3(0f, -speed, 0f);
    }

    // Update is called once per frame
    void Update() {

        Vector3 targetVector = hoverPosition - transform.position;
        targetVector = targetVector.normalized * speed;

        Vector3 newVector = Vector3.RotateTowards(new Vector3(rb.velocity.x, rb.velocity.y, 0f), targetVector, rotationSpeed, 1f);
        rb.velocity = newVector;

        Debug.Log(transform.position + " ** " + rb.velocity + " ** " + newVector + " ** " + targetVector);

    }
}
