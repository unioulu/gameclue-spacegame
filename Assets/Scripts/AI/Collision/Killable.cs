using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 3;
    protected int health;

    public Audiobank enemyDeathSound;
    public Audiobank enemyHitSound;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0) {
            if (enemyDeathSound != null)
            {
                enemyDeathSound.PlayOnce();
            }
            Destroy(gameObject);
            OnDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (enemyHitSound != null)
            {
                enemyHitSound.PlayOnce();
            }
            health -= other.gameObject.GetComponent<Bullet>().damage;
        }
    }

    protected virtual void OnDeath()
    {

    } 
}
