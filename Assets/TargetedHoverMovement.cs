using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedHoverMovement : MonoBehaviour
{
    public Vector3 targetCenterPosition;
    private Vector3 targetLeftCenterPosition;
    public float hoverRadius = 3f;
    public float speed = 1;
    private Rigidbody2D rb;
    private HoverMovement hoverMovement;

    void Awake()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        this.hoverMovement = this.gameObject.GetComponent<HoverMovement>();
        this.hoverMovement.enabled = false;
    }

    void Update()
    {
        if (!IsAtTarget())
        {
            this.targetLeftCenterPosition = targetCenterPosition - new Vector3(-hoverRadius, 0, 0);
            Vector3 currentPosition = this.transform.position;
            Vector3 direction = targetLeftCenterPosition - currentPosition;
            direction = direction.normalized;

            this.rb.velocity = direction * speed;
        }
        else
        {
            // Activate HoverMovement
            this.rb.velocity = Vector3.zero;
            hoverMovement.setTargetPoint(targetCenterPosition);
            hoverMovement.setTargetRadius(this.hoverRadius);

            this.enabled = false;
            hoverMovement.enabled = true;
 
        }
    }

    bool IsAtTarget()
    {
        return Vector3.Distance(this.rb.position, targetCenterPosition) <= hoverRadius;
    }
}
