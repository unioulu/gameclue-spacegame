using UnityEngine;

public class SinMovementEnemy : MonoBehaviour
{
    public Vector3 position;
    public float speed = 1;
    public Vector3 direction = new Vector3(0,1f,0);

    void Start()
    {
      position = transform.position;
    }

    void Update()
    {
      this.position += -transform.up * Time.deltaTime * speed;
      this.transform.position = position + transform.right * Mathf.Sin(Time.time * 20f) * 0.5f;
    }
}
