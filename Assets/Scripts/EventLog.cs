using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EventLog {

    public string message { private set; get; }
    public string timestamp { private set; get; }

    public EventLog(string message)
    {
        this.message = message;
        timestamp = Time.time.ToString();
    }

    override public string ToString()
    {
        return timestamp + " , " + message;
    }

}
