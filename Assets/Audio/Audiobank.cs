using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiobank : MonoBehaviour
{
    public GameObject soundManager;
    public AudioClip audioClip;

    private GameObject smInstance;

    public void PlayOnce()
    {
        smInstance = Instantiate(soundManager);
        AudioSource ass = smInstance.GetComponent<AudioSource>();
        ass.PlayOneShot(audioClip);
        Destroy(smInstance, audioClip.length);
    }

}
