using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{

    public GameObject bulletPrefab;
    public KeyCode shootKey = KeyCode.Space;
    private float maxKeyHoldTime = 1f;
    private float keyHoldTime = 0f;

    public Audiobank shootSound;

    private void Start()
    {
        maxKeyHoldTime = gameObject.GetComponent<ShootingPlayerChargeShot>().chargeTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shootKey))
        {
            keyHoldTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(shootKey))
        {
            if (keyHoldTime < maxKeyHoldTime)
            {
                shootSound.PlayOnce();
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                EventLogger.Log(EventLog.EventCode.PlayerFiredNormalShot());
            }
            keyHoldTime = 0f;
        }
    }
}
