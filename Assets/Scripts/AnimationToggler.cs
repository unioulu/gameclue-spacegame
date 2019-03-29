using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animator[] animList = GetComponents<Animator>();
        foreach (Animator anim in animList)
        {
            anim.enabled = CueManager.HasCues();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
