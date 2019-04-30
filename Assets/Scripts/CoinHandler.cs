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
    private float boundary_left = -10f;
    private float boundary_right = 10f;
    public float spawnpointOffset = 0.6f;
    private bool dir = true;
    private float spawnTimer;
    private float negSpawnTimer;

    private void Start()
    {
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        boundary_left = -edgeVector.x + spawnpointOffset;
        boundary_right = edgeVector.x - spawnpointOffset;
    }

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
        EventLogger.Log(EventLog.EventCode.PickUpSpawned(coinInstance.name, coinInstance.transform.position.x, coinInstance.transform.position.y));
    }

    public void SetScore(int amount)
    {
        score += amount;
    }

    private void OnGUI()
    {
        int width = score.ToString().Length * 12;
        GUI.TextField(new Rect(Screen.width/2 - width/2, 0, 70 + width, 30), "Score: " + score.ToString());
        GUI.skin.textField.fontSize = 20;
    }
}
