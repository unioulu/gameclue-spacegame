using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMovement : MonoBehaviour
{

    public float homingStartPosition = 4f;
    public float speed = 1f;
    public float homingTime = 1f;
    public float homingSpeed = 2f;

    public AngleSelectorTarget homingSelector;
    public Rigidbody2D rb = null;

    public Color homingColor = Color.red;
    public float homingBlinkCount = 4f;

    private bool accuiringTarget = false;
    private bool targetAccuired = false;

    private float timeSpentLookingforTarget = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.down * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.position.y < homingStartPosition && targetAccuired == false && accuiringTarget == false)
        {
            rb.velocity = homingSelector.NormalizedVector() * homingSpeed;
            accuiringTarget = true;
        } else if (accuiringTarget)
        {
            rb.velocity = Vector2.zero;
            timeSpentLookingforTarget += Time.deltaTime;
            Blink();
            if (timeSpentLookingforTarget > homingTime)
            {
                rb.velocity = homingSelector.NormalizedVector() * homingSpeed;
                accuiringTarget = false;
                targetAccuired = true;
            }
        }

    }


    void Blink()
    {
        if (CueManager.HasCues())
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = Color.Lerp(Color.white, homingColor, Mathf.PingPong(timeSpentLookingforTarget, homingTime / homingBlinkCount));
        }
    }

}
