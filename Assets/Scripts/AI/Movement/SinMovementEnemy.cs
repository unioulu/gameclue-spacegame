using UnityEngine;

public class SinMovementEnemy : MonoBehaviour
{
    public Vector3 position;
    public float speed = 1;
    public Vector3 direction = new Vector3(0,1f,0);

    public float amplitude = 3f;

    private Rigidbody2D rb = null;
    private float startXPos = 0f;
    private float lifetime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = rb.position;
        startXPos = rb.position.x;
        Debug.Log("startX: " + startXPos);
    }

    private void FixedUpdate()
    {
        this.lifetime += Time.fixedDeltaTime;
        float yPos = rb.position.y - Time.fixedDeltaTime * speed;
        float xPos = startXPos + Mathf.Sin(lifetime) * amplitude;
        rb.MovePosition(new Vector2(xPos, yPos));
    }
}
