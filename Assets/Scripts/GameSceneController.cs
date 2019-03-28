using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    private float lastEscapePress = 0f;
    private bool escapePressed = false;

    [SerializeField]
    private float quitDelay = 2f;

    private const float shakeOffset = 0.05f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapePressed = true;
            lastEscapePress = Time.unscaledTime;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);
            escapePressed = false;
        }

        if (escapePressed)
        {
            Camera cam = Camera.main;
            cam.transform.position = new Vector3(Random.Range(-shakeOffset, shakeOffset), Random.Range(-shakeOffset, shakeOffset), cam.transform.position.z);
            if (Time.unscaledTime - lastEscapePress > quitDelay)
            {
                EventLogger.Log(EventLog.EventCode.GameQuit());
                Application.Quit();
            }
        }

    }
}
