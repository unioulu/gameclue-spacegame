using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public Vector3 targetPoint;
    public float targetRadius;
    public float speed = 1;
    private float rotateSpeed = 3f;
    private float angle = 0;
    

    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        this.angle = Vector3.SignedAngle(Vector3.right, transform.position - targetPoint, Vector3.forward);
        this.angle = this.angle * Mathf.Deg2Rad;
    }

    void Update()
    {
        this.angle = angle + rotateSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Cos(this.angle), Mathf.Sin(this.angle), 0) * targetRadius;
        transform.position = targetPoint + offset;
    }

    public void setTargetPoint(Vector3 targetPoint)
    {
        this.targetPoint = targetPoint;
    }

    public void setTargetRadius(float targetRadius)
    {
        this.targetRadius = targetRadius;
    }

}