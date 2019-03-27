using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithVelocity : MonoBehaviour
{

    public Rigidbody2D rb = null;

    private float yRotation = 0;
    private float xRotation = 0;

    public float maxYRotation = 1f;
    public float maxXRotation = 1f;

    public float rotationSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity;

        transform.Rotate(-xRotation, -yRotation, 0f);
        
        if (velocity.x < 0)
        {
            yRotation = Mathf.Min(maxYRotation, yRotation + rotationSpeed);
        }
        else if (velocity.x > 0)
        {
            yRotation = Mathf.Max(-maxYRotation, yRotation - rotationSpeed);
        } else
        {
            yRotation += yRotation > 0 ? -rotationSpeed : rotationSpeed;
        }

        transform.Rotate(xRotation, yRotation, 0f);
    }
}
