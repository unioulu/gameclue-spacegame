using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);
        spawnTimer = 0;
        spawnList.GenerateRandomly();
        nextSpawn = spawnList.NextItemAtTime(spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        Debug.Log(spawnTimer + " " + nextSpawn.time);

        if (spawnTimer > nextSpawn.time)
        {
            GameObject.Instantiate(nextSpawn.enemyData.prefab, new Vector3(nextSpawn.spawnPosition, transform.position.y, transform.position.z), Quaternion.identity);
            nextSpawn = spawnList.NextItemAtTime(spawnTimer + 0.001f);
        }

        /*
        if (transform.position.x < boundary_left || transform.position.x > boundary_right) { direction = !direction; }

        if (direction) { transform.Translate(new Vector3(speed,0,0)); }
        else { transform.Translate(new Vector3(-speed, 0, 0)); }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= enemySpawnRate)
        {
            GameObject prefab = enemyPrefabs[Random.Range((int)0, (int)enemyPrefabs.Length)];
             Instantiate(prefab, transform.position, Quaternion.identity);
            spawnTimer = 0;
            enemySpawnRate = RandomSpawnrate();
        }
        */
    }

    float RandomSpawnrate()
    {
        return Random.Range(2f, 6f);
    }
}