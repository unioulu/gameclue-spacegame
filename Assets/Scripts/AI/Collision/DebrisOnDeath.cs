using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisOnDeath : Killable
{

    [SerializeField]
    private StraightMovement debrisPrefab;

    [SerializeField]
    private float debrisSpread = 0.5f;    [SerializeField]    private float debrisAngle = 0.5f;


    protected override void OnDeath()
    {
        Vector3 pos = transform.position;

        StraightMovement debris1 = Instantiate(debrisPrefab, new Vector3(pos.x + debrisSpread, pos.y, pos.z), Quaternion.identity);
        StraightMovement debris2 = Instantiate(debrisPrefab, new Vector3(pos.x - debrisSpread, pos.y, pos.z), Quaternion.identity);

        debris1.SetSpeedAndAngle(1f, debrisAngle);
        debris2.SetSpeedAndAngle(1f, -debrisAngle);
    }
}
