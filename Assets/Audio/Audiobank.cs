using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiobank : MonoBehaviour
{
    public GameObject soundManager;
    public AudioClip audioClip;
    private AudioSource ass;
    private GameObject smInstance;

    public void PlayOnce()
    {
        if (CueManager.HasCues())
        {
            smInstance = Instantiate(soundManager);
            ass = smInstance.GetComponent<AudioSource>();
            ass.PlayOneShot(audioClip);
            Destroy(smInstance, audioClip.length);
        }
    }

    public void PlayLoop()
    {
        if (CueManager.HasCues())
        {
            smInstance = Instantiate(soundManager);
            ass = smInstance.GetComponent<AudioSource>();
            ass.loop = true;
            ass.clip = audioClip;
            ass.Play();
        }
    }

    public void StopPlay()
    {
        if(ass != null)
            ass.Stop();
        Destroy(smInstance, audioClip.length);
    }

}
