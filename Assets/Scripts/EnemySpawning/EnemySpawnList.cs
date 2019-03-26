using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnList : MonoBehaviour
{

    public EnemyList enemies;
    private List<EnemySpawnListItem> spawnList;

    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 1.5f;

    public float minSpawnPosition = -7f;
    public float maxSpawnPosition = 7f;

    public void LoadFromFile()
    {
        //TODO: Implement LoadFromFile
        Debug.LogError("EnemySpawnList.LoadFromFile not implemented yet.");
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
        Debug.Log(spawnList.Count);
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

}
