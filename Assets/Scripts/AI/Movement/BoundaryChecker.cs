using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour
{

    public bool active = true;
    public float distance = 10f;

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
        /*
        if (active && Vector3.Distance(Vector3.zero, transform.position) > distance)
        {
            Destroy(this.gameObject);
        }
        */

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(edgeVector.x) || Mathf.Abs(transform.position.y) > Mathf.Abs(edgeVector.y) + 2f)
        {
            Destroy(this.gameObject);
        }
    }
}
