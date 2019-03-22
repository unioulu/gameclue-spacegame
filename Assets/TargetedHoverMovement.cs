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

    void Awake()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        this.targetLeftCenterPosition = targetCenterPosition - new Vector3(-hoverRadius,0,0);
    }

    void Update()
    {
        if (!IsAtTarget())
        {
            Vector3 currentPosition = this.transform.position;
            Vector3 direction = targetLeftCenterPosition - currentPosition;
            direction = direction.normalized;

            this.rb.velocity = direction * speed;
        }
        else
        {
            this.rb.velocity = Vector3.zero;
            // Activate hover movement
            // HoverMovement hoverMovement = this.gameObject.GetComponent<HoverMovement>();
            // hoverMovement.setHover(center);
            // this.enabled = false;
        }
    }

    bool IsAtTarget()
    {
        return Vector3.Distance(this.rb.position, targetCenterPosition) <= hoverRadius;
    }
}
