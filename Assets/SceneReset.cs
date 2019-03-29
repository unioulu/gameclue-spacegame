using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneReset : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
