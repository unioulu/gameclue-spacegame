using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    public float boundaryLeft = -6f;
    public float boundaryRight = 6f;

    private float spawntime = 1f;

    public BackgroundObject[] backgroundPrefabs;

    private System.Random random;

    public int seed = 200;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random(seed);
    }

    // Update is called once per frame
    void Update()
    {

        spawntime -= Time.deltaTime;

        if (spawntime <= 0)
        {
            SpawnStar();
            spawntime = NewSpawnTime();
        }

    }

    private void SpawnStar()
    {
        BackgroundObject star = GameObject.Instantiate<BackgroundObject>(backgroundPrefabs[Random.Range(0, backgroundPrefabs.Length)], StarPosition(), Quaternion.identity);
        star.speed = StarSpeed();
    }

    private Vector3 StarPosition()
    {
        return new Vector3(Random.Range(boundaryLeft, boundaryRight), transform.position.y, transform.position.z);
    }

    private float StarSpeed()
    {
        return Random.Range(0.1f, 0.9f);
    }

    private float NewSpawnTime()
    {
        return Random.Range(0.5f, 3f);
    }
}
