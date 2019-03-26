using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObject : MonoBehaviour
{

    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * Time.deltaTime * speed;
    }
}
