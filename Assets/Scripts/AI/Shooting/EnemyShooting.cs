using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Bullet bulletPrefab;

    public int shootCooldown = 2;
    public float shootWarningtime = 0.5f;
    public float bulletSpeed = 4f;

    public AngleSelector selector;

    public Sprite idleSprite;
    public Sprite prepareSprite;
    public Sprite shootSprite;
    private Sprite currentSprite = null;

    private float shootTimer;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = selector.NormalizedVector();

        shootTimer += Time.deltaTime;

        if (shootTimer > shootCooldown)
        {
            Bullet bulletInstance = Instantiate<Bullet>(bulletPrefab, transform.position, Quaternion.identity);
            bulletInstance.speed = bulletSpeed;
            bulletInstance.Angle = Vector3.SignedAngle(selector.NormalizedVector(), Vector3.right, Vector3.back) * Mathf.Deg2Rad;
            //bulletInstance.GetComponent<Rigidbody2D>().velocity = targetVector * bulletSpeed;
            shootTimer = 0;
            ShowSprite(shootSprite);
        }
        else if (shootTimer > shootCooldown - shootWarningtime)
        {
            ShowSprite(prepareSprite);
        } 
        else if (shootTimer > 0.05f)
        {
            ShowSprite(idleSprite);
        }
    }

    void ShowSprite(Sprite sprite) {
        if (currentSprite != sprite)
        {
            currentSprite = sprite;
            SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = sprite;
        }
    }
}
