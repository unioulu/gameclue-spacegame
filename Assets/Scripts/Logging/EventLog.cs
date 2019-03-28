using UnityEngine;

public class EventLog
{
    public static class EventCode
    {
        // Game/application level events
        public static string GameStarted() { return "GameStarted"; }
        public static string GameEnded(string reason) { return "GameQuit|" + reason; }
        public static string GameHasCues(bool hasCues) { return "HasCues|" + hasCues; } // TODO

        // Input events
        public static string InputKeyUp(KeyCode key) { return "KeyUp|" + key; }
        public static string InputKeyDown(KeyCode key) { return "KeyDown|" + key; }

        // Player events
        public static string PlayerReceivedDamage(string damageSourceId, int damageAmount) { return "PlayerReceivedDamage|" + damageSourceId + "|" + damageAmount; }
        public static string PlayerDied(string damageSourceId, int damageAmount) { return "PlayerDied|" + damageSourceId + "|" + damageAmount; }
        public static string PlayerFiredNormalShot() { return "PlayerFiredNormalShot"; }
        public static string PlayerFiredChargedShot() { return "PlayerFiredChargedShot"; }
        public static string PlayerCollidesWithPickUp(string pickUp) { return "PlayerCollidesWithPickUp|" + pickUp; }

        // Enemy events
        public static string EnemySpawned(string enemyId, float xPos, float yPos) { return "EnemySpawned|" + enemyId + "|" + xPos + "|" + yPos; }
        public static string EnemyDied(string enemyId, float xPos, float yPos) { return "EnemyDied|" + enemyId + "|" + xPos + "|" + yPos; }
        public static string EnemyFiredNormalShot(string enemyId) { return "EnemyFiredNormalShot " + enemyId; } // TODO
        public static string EnemyReceivedDamage(string enemyId) { return "EnemyReceivedDamage " + enemyId; } // TODO

        // Pickup events
        public static string PickUpSpawned(string pickUpId, float x, float y) { return "PickUpSpawned|" + pickUpId; }
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
        return "\"" + timestamp + "\";\"" + message + "\"";
    }

}
