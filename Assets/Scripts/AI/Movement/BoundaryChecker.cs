using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour
{

    public bool active = true;
    public float distance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled && Vector3.Distance(Vector3.zero, transform.position) > distance)
        {
            Destroy(this.gameObject);
        }
    }
}
