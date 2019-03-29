using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.AltGr)) {
            if (Input.GetKeyUp(KeyCode.F1))
            {
                ChangeToMutation("BaseGameScene");
            }
            else if (Input.GetKeyUp(KeyCode.F2))
            {
                ChangeToMutation("PointGameScene");
            }
            else if (Input.GetKeyUp(KeyCode.F3))
            {
                ChangeToMutation("MovementGameScene");
            }
            else if (Input.GetKeyUp(KeyCode.F4))
            {
                ChangeToMutation("ShootGameScene");
            }
            else if (Input.GetKeyUp(KeyCode.F5))
            {
                ChangeToMutation("InputGameScene");
            }
        }

        if (escapePressed)
        {
            Camera cam = Camera.main;
            cam.transform.position = new Vector3(Random.Range(-shakeOffset, shakeOffset), Random.Range(-shakeOffset, shakeOffset), cam.transform.position.z);
            if (Time.unscaledTime - lastEscapePress > quitDelay)
            {
                EventLogger.Log(EventLog.EventCode.GameEnded("InputEscapePressed"));
                Application.Quit();
            }
        }

    }

    void ChangeToMutation(string name)
    {
        MutationManager.SetMutationName(name);
        EventLogger.Log("ChangedScene|" + MutationManager.MutationName());
        SceneManager.LoadScene("SplashScreen");
    }
}
