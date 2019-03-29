using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 1f;
    public int scoreValue = 100;

    public CoinHandler CoinHandler { set; private get; }

    private Audiobank ab;
    private GameObject soundManagerInstance;
    private Rigidbody2D rb;

    void Start()
    {
        ab = gameObject.GetComponent<Audiobank>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, -speed, 0);
        if (transform.position.y < -5f) { Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventLogger.Log(EventLog.EventCode.PlayerCollidesWithPickUp(this.name));
            CoinHandler.SetScore(scoreValue);
            ab.PlayOnce();
            Destroy(gameObject);
        }
    }
}
