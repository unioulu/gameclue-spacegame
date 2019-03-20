using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisOnDeath : MonoBehaviour
{

    [SerializeField]
    private StraightMovement debrisPrefab;

    [SerializeField]
    private float debrisSpread = 0.5f;    [SerializeField]    private float debrisAngle = 0.5f;

    [SerializeField]
    private int maxHealth = 3;
    public int health { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)    {        Vector3 pos = transform.position;        if (other.tag == "Bullet")        {            Debug.Log("HIT");            health--;            if (health <= 0)            {                            StraightMovement debris1 = Instantiate(debrisPrefab, new Vector3(pos.x + debrisSpread, pos.y, pos.z), Quaternion.identity);                StraightMovement debris2 = Instantiate(debrisPrefab, new Vector3(pos.x - debrisSpread, pos.y, pos.z), Quaternion.identity);

                debris1.SetSpeedAndAngle(1f, debrisAngle);
                debris2.SetSpeedAndAngle(1f, -debrisAngle);

                Destroy(gameObject);            }        }    }
}
