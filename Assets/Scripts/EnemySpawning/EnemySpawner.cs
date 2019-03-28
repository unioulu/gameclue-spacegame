using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float speed = 0.1f;
    public float enemySpawnRate = 4;

    public GameObject[] enemyPrefabs;

    private float boundary_left = -10f;
    private float boundary_right = 10f;
    private bool direction = true;

    public int seed = 100;

    private float spawnTimer;

    public EnemySpawnList spawnList;
    public float lastSpawnTime = 0f;
    private EnemySpawnListItem nextSpawn = null;

    void Start()
    {
        Random.InitState(seed);
        spawnTimer = 0;
        spawnList.GenerateRandomly();
        nextSpawn = spawnList.NextItemAtTime(spawnTimer);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > nextSpawn.time)
        {
            GameObject.Instantiate(nextSpawn.enemyData.prefab, new Vector3(nextSpawn.spawnPosition, transform.position.y, transform.position.z), Quaternion.identity);
            EventLogger.Log(EventLog.EventCode.EnemySpawned(nextSpawn.enemyData.prefab.name, nextSpawn.spawnPosition, transform.position.y));
            nextSpawn = spawnList.NextItemAtTime(spawnTimer + 0.001f);
        }
    }

    float RandomSpawnrate()
    {
        return Random.Range(2f, 6f);
    }
}
