﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EventLogger
{

    private static EventLogger instance = null;

    private List<EventLog> logs;
    private List<EventLog> fpsLogs;

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
        fpsLogs = new List<EventLog>();
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

    public static void LogFps(float fps)
    {
        singleton().fpsLogs.Add(new EventLog(fps.ToString()));
        singleton().WriteFpsToFile();
    }

    public static void AddLog(EventLog log)
    {
        singleton().logs.Add(log);
        singleton().WriteLogsToFile();
    }

    public void DebugPrint()
    {
        foreach (EventLog log in logs)
        {
            Debug.Log(log.ToString());
        }
    }

    public void WriteLogsToFile()
    {
        WriteFile("log", logs);
    }

    public void WriteFpsToFile()
    {
        WriteFile("fps", fpsLogs);
    }

    public void WriteFile(string fileNameAppend, List<EventLog> logList)
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, gameName + "-" + fileNameAppend + ".txt");

        using (StreamWriter file = new StreamWriter(filePath, true))
        {
            foreach (EventLog log in logList)
            {
                file.WriteLine(log.ToString());
            }
            logList.Clear();
        }
    }

}
