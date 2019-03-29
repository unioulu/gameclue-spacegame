using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{

    public List<GameObject> defaultPrefabs;

    public class EnemyData
    {
        public string id { private set; get; }
        public GameObject prefab { private set; get; }

        public EnemyData(string id, GameObject prefab)
        {
            this.id = id;
            this.prefab = prefab;
        }
    }

    public List<EnemyData> list { get; private set; }

    public void Awake()
    {
        list = new List<EnemyData>();
        LoadDefaults();
    }

    public void LoadDefaults()
    {
        foreach (GameObject obj in defaultPrefabs) {
            EnemyData data = new EnemyData(obj.name, obj);
            list.Add(data);
        }
    }

}
