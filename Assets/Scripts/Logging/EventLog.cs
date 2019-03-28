using UnityEngine;

public class EventLog
{
    public static class EventCode
    {
        // Game/application level events
        public static string GameStarted() { return "GameStarted"; }
        public static string GameQuit() { return "GameQuit"; }
        public static string GameHasCues(bool hasCues) { return "HasCues " + hasCues; }

        // Input events
        public static string InputKeyUp(KeyCode key) { return "KeyUp " + key; }
        public static string InputKeyDown(KeyCode key) { return "KeyDown " + key; }

        // Player events
        public static string PlayerReceivedDamage(string damageSourceId, int damageAmount) { return "PlayerDamaged " + damageSourceId; }
        public static string PlayerFiredNormalShot() { return "PlayerFiredNormalShot"; }
        public static string PlayerFiredChargedShot() { return "PlayerFiredChargedShot"; }

        // Enemy events
        public static string EnemySpawned(string enemyId, float xPos, float yPos) { return "EnemyCreated " + enemyId; } // unhooked
        public static string EnemyDied(string enemyId) { return "EnemyDied " + enemyId; }
        public static string EnemyFiredNormalShot(string enemyId) { return "EnemyFiredNormalShot " + enemyId; }
        public static string EnemyReceivedDamage(string enemyId) { return "EnemyReceivedDamage " + enemyId; } // unhooked
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
