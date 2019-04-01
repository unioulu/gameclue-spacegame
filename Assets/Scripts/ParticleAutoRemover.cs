using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoRemover : MonoBehaviour
{

    private ParticleSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = GetComponent<ParticleSystem>();
        if (system == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (system)
        {
            if (!system.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
