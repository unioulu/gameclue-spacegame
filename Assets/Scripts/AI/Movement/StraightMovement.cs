using System.Collections;using System.Collections.Generic;using UnityEngine;public class StraightMovement : MonoBehaviour{    [SerializeField]    private Rigidbody2D rb;    public float speed = 0.8f;    public float angle = 0f;    // Start is called before the first frame update    void Start() {        SetSpeedAndAngle(speed, angle);    }    // Update is called once per frame    void Update()    {            }    public void SetSpeedAndAngle(float speed, float angle)
    {
        this.speed = speed;
        this.angle = angle;
        Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(angle, -speed, 0f);
    }}