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

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(seed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < boundary_left || transform.position.x > boundary_right) { direction = !direction; }

        if (direction) { transform.Translate(new Vector3(speed,0,0)); }
        else { transform.Translate(new Vector3(-speed, 0, 0)); }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= enemySpawnRate)
        {
            GameObject prefab = enemyPrefabs[2];//Random.Range((int)0, (int)enemyPrefabs.Length)];
            Instantiate(prefab, transform.position, Quaternion.identity);
            spawnTimer = 0;
            enemySpawnRate = RandomSpawnrate();
        }

    }

    float RandomSpawnrate()
    {
        return Random.Range(2f, 6f);
    }
}
