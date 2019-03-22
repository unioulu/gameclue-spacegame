using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Moves gameobject in circles.
 * Uses either
 *   - current position
 *   - given position
 */
public class CircleMovement : MonoBehaviour
{
    public float initialHoverPositionX = 0;
    public float initialHoverPositionY = 0;
    public float addY = 0;
    private float yPos;
    public float addX = Mathf.PI/2f;
    private float xPos;
    public float sinStrength = 1;
    public float speed = 2; 

    // Use this for initialization
    void Start()
    {
        yPos = transform.position.y;
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Update is called once per frame
        this.transform.position = new Vector3(1, 1, 0);
        this.transform.localScale = new Vector3(15, 15, 0);

        addY += Time.deltaTime * speed;
        float sinY = sinStrength * Mathf.Sin(addY);

        addX += Time.deltaTime * speed;
        float sinX = sinStrength * Mathf.Sin(addX);
        
        Vector3 oldVector = transform.position;
        transform.position = new Vector3(initialHoverPositionX + sinX, initialHoverPositionY + sinY, transform.position.z);
        
        Vector3 moveVector = oldVector - transform.position;
        
        // this.transform.Rotate(0,0,0.5f,new Space());
        // Turn(moveVector);
    }
}
