using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerChargeShot : MonoBehaviour
{

    public GameObject chargeBulletPrefab;

    public int chargeTime = 1;
    public int bulletAmnt = 10;
    public float spreadAmnt = .1f;
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
                for (int i=-(int)Mathf.Floor(bulletAmnt/2); i<(int)Mathf.Floor(bulletAmnt/2); i++)
                {
                    GameObject bulletinstance = Instantiate(chargeBulletPrefab, transform.position, Quaternion.identity);
                    bulletinstance.GetComponent<Bullet>().Angle = i * spreadAmnt + .5f * Mathf.PI;
                }
            }
            chargeParticles.Stop();
            chargeParticles.Clear();
            charge = 0;
        }
    }
}
