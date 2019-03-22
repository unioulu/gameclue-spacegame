using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    private float timeToDirectionChange = 0;

    private float rotationSpeed = 0.2f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 0.8f;
    
    private Vector3 nextVector;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = RandomVector();
        ChangeVector();
        RandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeToDirectionChange -= Time.deltaTime;

        if (timeToDirectionChange < 0)
        {
            timeToDirectionChange = RandomTime();
            ChangeVector();
        }

        rb.velocity = Vector3.RotateTowards(rb.velocity, nextVector, rotationSpeed, 1f);
        
    }


    void ChangeVector()
    {
        nextVector = RandomVector();
        nextVector.Normalize();
        nextVector *= speed;
    }

    Vector3 RandomVector()
    {
        return new Vector3(Random.Range(-1f, 1f), -1f, 0f);
    }

    float RandomTime()
    {
        return Random.Range(1f, 3f);
    }
}
