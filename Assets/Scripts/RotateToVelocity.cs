using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour
{

    public Rigidbody2D rb = null;

    private float previousRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, -previousRotation);
        previousRotation = Vector3.SignedAngle(Vector3.up, rb.velocity, Vector3.forward);
        transform.Rotate(0f, 0f, previousRotation);
    }
}
