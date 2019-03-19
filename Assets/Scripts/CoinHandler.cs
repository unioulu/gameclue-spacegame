using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject negCoinPrefab;
    public float speed = 0.1f;
    public int coinSpawnRate = 8;
    public int negCoinSpawnRate = 10;

    private GameObject coinInstance;

    private int score;
    readonly float boundary_left = -10f;
    readonly float boundary_right = 10f;
    private bool dir = true;
    private float spawnTimer;
    private float negSpawnTimer;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < boundary_left || transform.position.x > boundary_right) { dir = !dir; }

        if (dir) { transform.Translate(new Vector3(speed, 0, 0)); }
        else { transform.Translate(new Vector3(-speed, 0, 0)); }

        spawnTimer += Time.deltaTime;
        negSpawnTimer += Time.deltaTime;

        if (spawnTimer >= coinSpawnRate)
        {
            InstantiateCoin(coinPrefab);
            spawnTimer = 0;
        }
        if (negSpawnTimer >= negCoinSpawnRate)
        {
            InstantiateCoin(negCoinPrefab);
            negSpawnTimer = 0;
        }
    }

    private void InstantiateCoin(GameObject coin)
    {
        coinInstance = Instantiate(coin, transform.position, Quaternion.identity);
        coinInstance.GetComponent<Coin>().CoinHandler = this;
    }

    public void SetScore(int amount)
    {
        score += amount;
        if (score < 0)
            score = 0;
    }

    private void OnGUI()
    {
        int width = score.ToString().Length * 10;
        GUI.TextField(new Rect(Screen.width/2 - width/2, 0,50 + width, 20), "Score: " + score.ToString());
    }
}
