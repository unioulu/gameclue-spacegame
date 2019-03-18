using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class EventLogger
{

    private static EventLogger instance = null;

    private List<EventLog> logs;

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
    }


    public void Log(string message)
    {
        AddLog(new EventLog(message));
    }

    public void AddLog(EventLog log)
    {
        logs.Add(log);
    }

    public void WriteToFile()
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        using (StreamWriter file = new StreamWriter(desktopPath))
        {
            foreach (EventLog log in logs)
            {
                file.WriteLine(log.ToString());
            }
        }



    }

}
