using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerChargeShot : MonoBehaviour
{

    public GameObject chargeBulletPrefab;

    public int chargeTime = 1;
    public float particleStartDelay = 0.2f;
    private float charge = 0f;

    public ParticleSystem chargeParticles;

    public KeyCode shootKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shootKey))
        {
            charge += Time.deltaTime;
            if (charge > particleStartDelay && chargeParticles.IsAlive() == false)
            {
                chargeParticles.Play();
            }
        }
        if (Input.GetKeyUp(shootKey))
        {
            if (charge > chargeTime)
            {
                Instantiate(chargeBulletPrefab, transform.position, Quaternion.identity);
            }
            chargeParticles.Stop();
            chargeParticles.Clear();
            charge = 0;
        }
    }
}
