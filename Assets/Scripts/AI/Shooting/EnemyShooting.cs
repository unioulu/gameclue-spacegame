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

    void Update()
    {
        Vector3 targetVector = selector.NormalizedVector();

        shootTimer += Time.deltaTime;

        if (shootTimer > shootCooldown)
        {
            Bullet bulletInstance = Instantiate<Bullet>(bulletPrefab);
            bulletInstance.transform.position = transform.position;
            bulletInstance.speed = bulletSpeed;
            float angle = Vector3.SignedAngle(selector.NormalizedVector(), Vector3.right, Vector3.back) * Mathf.Deg2Rad;
            bulletInstance.Angle = angle;
            EventLogger.Log(EventLog.EventCode.EnemyFiredNormalShot(bulletInstance.name, angle));
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
      if (CueManager.HasCues()) {
        if (currentSprite != sprite)
        {
            currentSprite = sprite;
            SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = sprite;
        }
      } else {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = idleSprite;
      }
    }
}
