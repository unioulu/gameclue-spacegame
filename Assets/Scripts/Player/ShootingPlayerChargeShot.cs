using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerChargeShot : MonoBehaviour
{

    public GameObject chargeBulletPrefab;

    public int bulletAmnt = 10;
    public float spreadAmnt = .1f;
    public float particleStartDelay = 0.2f;
    public float chargeTime = 1;
    private float charge = 0f;

    public ParticleSystem chargeParticles;

    public KeyCode shootKey = KeyCode.Space;

    public Audiobank chargeSound;
    public Audiobank chargeReadySound;
    public Audiobank chargeShotSound;
    public bool playloop = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            // Play charge start sound here
            chargeSound.PlayOnce();
        }
        if (Input.GetKey(shootKey))
        {
            charge += Time.deltaTime;
            if (charge > chargeTime && playloop)
            {
                // Play looping sound here
                chargeReadySound.PlayLoop();
                playloop = false;
            }
            if (charge > particleStartDelay && chargeParticles.IsAlive() == false)
            {
                chargeParticles.Play();
            }
        }
        if (Input.GetKeyUp(shootKey))
        {
            if (charge > chargeTime)
            {
                // Play charge release sound here
                chargeShotSound.PlayOnce();

                for (int i=-(int)Mathf.Floor(bulletAmnt/2); i<(int)Mathf.Floor(bulletAmnt/2); i++)
                {
                    GameObject bulletinstance = Instantiate(chargeBulletPrefab, transform.position, Quaternion.identity);
                    bulletinstance.GetComponent<Bullet>().Angle = i * spreadAmnt + .5f * Mathf.PI;
                }
            }
            chargeSound.StopPlay();
            chargeReadySound.StopPlay();
            chargeParticles.Stop();
            chargeParticles.Clear();
            charge = 0;
            playloop = true;
        }
        /*
        if (Input.GetKeyDown(SHOOT)) { chargeSound.PlayOnce(); }
        if (Input.GetKey(SHOOT))
        {
            charge += Time.deltaTime;
            if (charge > chargeTime && playloop)
            {
                // Play looping sound here
                chargeReadySound.PlayLoop();
                playloop = false;
            }
        }
        if (Input.GetKeyUp(SHOOT))
        {
            if (charge > chargeTime)
            {
                Instantiate(chargeBullet, transform.position, Quaternion.identity);
                chargeShotSound.PlayOnce();
            }
            else
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                shootSound.PlayOnce();
            }

            chargeSound.StopPlay();
            chargeReadySound.StopPlay();
            charge = 0;
            playloop = true;
        }*/

    }
}
