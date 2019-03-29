using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemySpawnList : MonoBehaviour
{

    public EnemyList enemies;
    private List<EnemySpawnListItem> spawnList;

    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;

    private float minSpawnPosition = -7f;
    private float maxSpawnPosition = 7f;
    public float spawnpointOffset = 0.6f;

    private void Start()
    {
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        minSpawnPosition = -edgeVector.x + spawnpointOffset;
        maxSpawnPosition = edgeVector.x - spawnpointOffset ;
    }

    public void GenerateRandomly()
    {
        spawnList = new List<EnemySpawnListItem>();
        float spawntime = 0f;

        for (int i=0; i<50; ++i)
        {
            spawntime += Random.Range(minSpawnTime, maxSpawnTime);
            float position = Random.Range(minSpawnPosition, maxSpawnPosition);
            float index = Random.Range(0, enemies.list.Count);
            EnemyList.EnemyData enemyData = enemies.list[(int)index];

            EnemySpawnListItem spawnEvent = new EnemySpawnListItem(spawntime, position, enemyData);

            spawnList.Add(spawnEvent);
        }
    }

    public float TotalTime()
    {
        return spawnList[spawnList.Count - 1].time;
    }

    public EnemySpawnListItem NextItemAtTime(float time)
    {
        float originalTime = time;
        float reducedTime = 0f;
        while (time > TotalTime())
        {
            time -= TotalTime();
            reducedTime += TotalTime();
        }

        foreach (EnemySpawnListItem spawn in spawnList)
        {
            if (time < spawn.time)
            {
                //Create new ListItem so that time is correct based on loops
                return new EnemySpawnListItem(spawn.time + reducedTime, spawn.spawnPosition, spawn.enemyData);
            }
        }
        Debug.LogError("EnemySpawnList NextItemAtTime failed to find an enemy to spawn at time " + originalTime);
        return null;
    }

    public void WriteToFile(string path)
    {
        StreamWriter file = new StreamWriter(path, false);

        foreach (EnemySpawnListItem item in spawnList)
        {
            string line = item.time + "; " + item.spawnPosition + "; " + item.enemyData.id;
            file.WriteLine(line);
        }
    }

    public void LoadFromFile(string path)
    {
        Debug.LogError("EnemySpawnList LoadFromFile not implemented yet.");
    }

}
