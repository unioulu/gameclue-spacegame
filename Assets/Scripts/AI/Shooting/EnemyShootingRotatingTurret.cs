using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingRotatingTurret : MonoBehaviour
{

    public AngleSelector selector;

    float previousAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = selector.NormalizedVector();
        transform.Rotate(0f, 0f, -previousAngle); //Negate previous rotation, in order to not calculate the difference between rotations
        previousAngle = Vector3.SignedAngle(targetVector, Vector3.up, Vector3.back);
        transform.Rotate(0f, 0f, previousAngle);
    }
}
