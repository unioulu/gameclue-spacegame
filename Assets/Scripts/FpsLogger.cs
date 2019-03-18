using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class FpsLogger : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private float msec;
    private float fps;
    private string text;
    private List<string> fpsData = new List<string>();

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        msec = deltaTime * 1000.0f;
        fps = 1.0f / deltaTime;
        text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        fpsData.Add(text);
    }

    public void FpsToFile()
    {
        /*TODO: specify file destination
         *        
        string destination = Application.dataPath;    <--  This returns the path of the assets folder
        DirectoryInfo parent = Directory.GetParent(destination);

        System.IO.File.WriteAllLines(destination, fpsData);
        Debug.Log(destination);*/
    }

    /*void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        // GUI.Label(rect, text, style);
    }*/
}
