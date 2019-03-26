using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList
{

    public class EnemyData
    {
        public string id;
        GameObject prefab;

        public EnemyData(string id, GameObject prefab)
        {

        }

        public void Construct()
        {
            GameObject.Instantiate(prefab);
        }
    }

    private List<EnemyData> enemyList;

    public void LoadDefaults()
    {
        var asteroid = new EnemyData("asteroid", Resources.Load();
    }

}
