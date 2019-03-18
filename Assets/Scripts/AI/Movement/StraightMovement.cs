using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float speed = 0.8f;
    public float angle = 1.5f * Mathf.PI;

    // Start is called before the first frame update
    void Start() {
        SetSpeedAndAngle(speed, angle);
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedAndAngle(speed, angle);
    }

    public void SetSpeedAndAngle(float speed, float angle)
    {
        this.speed = speed;
        this.angle = angle;

        Vector3 velo = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        velo = velo * speed;
        this.rb.velocity = velo;
    }
}
