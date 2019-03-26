using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnListItem
{
    public float time { private set; get; }
    public float spawnPosition { private set; get; }
    public EnemyList.EnemyData enemyData { private set; get; }

    public EnemySpawnListItem(float time, float position, EnemyList.EnemyData data) {
        this.time = time;
        this.spawnPosition = position;
        this.enemyData = data;
   }
}
