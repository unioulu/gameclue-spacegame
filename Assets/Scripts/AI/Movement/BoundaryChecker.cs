using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour
{

    public bool active = true;
    public float offset = 0.6f;

    private Vector2 topRightCorner;
    private Vector2 edgeVector;

    // Start is called before the first frame update
    void Start()
    {
        topRightCorner = new Vector2(1, 1);
        edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
    }

    // Update is called once per frame
    void Update()
    {
        if (active && (Mathf.Abs(transform.position.x) > Mathf.Abs(edgeVector.x) || transform.position.y < -edgeVector.y -offset ))
        {
            Destroy(this.gameObject);
        }
    }
}
