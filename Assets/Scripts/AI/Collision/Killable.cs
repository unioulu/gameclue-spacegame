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

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0) {
            EventLogger.Log(EventLog.EventCode.EnemyDied(gameObject.name, gameObject.transform.position.x, gameObject.transform.position.y));
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
            int damage = other.gameObject.GetComponent<Bullet>().damage;
            health -= damage;
            EventLogger.Log(EventLog.EventCode.EnemyReceivedDamage(other.name, damage));
            if (enemyHitSound != null)
            {
                enemyHitSound.PlayOnce();
            }
        }
    }

    protected virtual void OnDeath()
    {

    }
}
