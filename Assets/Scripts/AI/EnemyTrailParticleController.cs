using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrailParticleController : MonoBehaviour
{

    public ParticleSystem particles = null;

    // Start is called before the first frame update
    void Start()
    {
        if (CueManager.HasCues())
        {
            particles.Play();
        }
        else
        {
            particles.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
