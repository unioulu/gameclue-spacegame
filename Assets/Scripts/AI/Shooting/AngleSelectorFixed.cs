using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleSelectorFixed : AngleSelector
{

    public Vector3 direction = Vector3.down;

    public override Vector3 NormalizedVector()
    {
        return direction.normalized;
    }

}
