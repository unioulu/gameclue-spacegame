using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToVelocity : MonoBehaviour
{

    public Rigidbody2D rb = null;

    private float previousRotation = 0f;

    private void Start()
    {
        if (CueManager.HasCues())
        {
            transform.rotation = Quaternion.identity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CueManager.HasCues())
        {
            transform.Rotate(0f, 0f, -previousRotation);
            previousRotation = Vector3.SignedAngle(Vector3.up, rb.velocity, Vector3.forward);
            transform.Rotate(0f, 0f, previousRotation);
        }
    }
}
