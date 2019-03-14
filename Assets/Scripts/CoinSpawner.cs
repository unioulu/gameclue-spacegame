using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float speed = 0.1f;
    public int coinSpawnRate = 8;

    private GameObject coinInstance;

    private int score;
    private float boundary_left = -10f;
    private float boundary_right = 10f;
    private bool dir = true;
    private float spawnTimer;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < boundary_left || transform.position.x > boundary_right) { dir = !dir; }

        if (dir) { transform.Translate(new Vector3(speed, 0, 0)); }
        else { transform.Translate(new Vector3(-speed, 0, 0)); }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= coinSpawnRate)
        {
            InstantiateCoin();
            spawnTimer = 0;
        }
    }

    private void InstantiateCoin()
    {
        coinInstance = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coinInstance.GetComponent<Coin>().CoinSpawner = this;
    }

    public void SetScore(int amount)
    {
        score += amount;
    }

    private void OnGUI()
    {
        GUI.TextField(new Rect(0, 0,50 + score.ToString().Length * 10, 20), "Score: " + score.ToString());
    }
}
