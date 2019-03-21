using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleSelectorTarget : AngleSelector
{

    public string targetTag = "Player";

    private GameObject target;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
    }


    override public Vector3 NormalizedVector()
    {
        return (target.transform.position - this.transform.position).normalized;
    }

    
}
