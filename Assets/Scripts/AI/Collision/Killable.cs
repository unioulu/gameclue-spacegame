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

    public Sprite dmg1Sprite = null;
    public Sprite dmg2Sprite = null;

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
            ChangeDamageSprite();
            EventLogger.Log(EventLog.EventCode.EnemyReceivedDamage(other.name, damage));
            if (enemyHitSound != null)
            {
                enemyHitSound.PlayOnce();
            }
        }
    }

    private void ChangeDamageSprite()
    {
        if (CueManager.HasCues()) {
            if (health == maxHealth - 1)
            {
                if (dmg1Sprite != null)
                {

                    GetComponent<SpriteRenderer>().sprite = dmg1Sprite;
                }
            }
            else if (health <= maxHealth - 2)
            {
                if (dmg2Sprite != null)
                {

                    GetComponent<SpriteRenderer>().sprite = dmg2Sprite;
                }
            }
        }
    }

    protected virtual void OnDeath()
    {

    }
}
