using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EventLogger
{

    private static EventLogger instance = null;

    private List<EventLog> logs;

    public string gameName = "Game";

    static EventLogger singleton()
    {
        if (instance == null)
        {
            instance = new EventLogger();
        }
        return instance;
    }

    private EventLogger()
    {
        logs = new List<EventLog>();
        gameName = "Game-" + UnityEngine.Random.Range(0, 9999);
    }


    public static void SetName(string name)
    {
        singleton().gameName = name;
    }

    public static void Log(string message)
    {
        AddLog(new EventLog(message));
    }

    public static void AddLog(EventLog log)
    {
        singleton().logs.Add(log);
        singleton().WriteToFile();
    }

    public void DebugPrint()
    {
        foreach (EventLog log in logs)
        {
            Debug.Log(log.ToString());
        }
    }

    public void WriteToFile()
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, gameName + "-log.txt");
        
        using (StreamWriter file = new StreamWriter(filePath, false))
        {
            foreach (EventLog log in logs)
            {
                file.WriteLine(log.ToString());
            }
        }



    }

}
