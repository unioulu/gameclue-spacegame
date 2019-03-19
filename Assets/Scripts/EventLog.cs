using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class EventLog {

    public static class EventCode
    {
        public static string KeyUp(KeyCode key) { return "KeyUp " + key; }
        public static string KeyDown(KeyCode key) { return "KeyDown " + key; }

        public const string damage = "PlayerDamage";
        public static string EnemyDamage(string enemyId) { return "EnemyDamage " + enemyId; }
        public static string EnemyCreated(string enemyId) { return "EnemyCreated " + enemyId; }
    }

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
