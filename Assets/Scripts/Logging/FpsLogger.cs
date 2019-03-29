using UnityEngine;

public class FpsLogger : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private string text;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        EventLogger.LogFps(fps);
    }
}
