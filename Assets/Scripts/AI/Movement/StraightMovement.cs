using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour {

  [SerializeField]
  private Rigidbody2D rb;
  public float speed = 0.8f;
  public float angle = 0f;

  void Start() {
    SetSpeedAndAngle(speed, angle);
  }

  public void SetSpeedAndAngle(float speed, float angle) {
        this.speed = speed;
        this.angle = angle;
        Rigidbody2D rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(angle, -speed, 0f);
  }
}
