using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogger : MonoBehaviour
{
    private System.Array codes;

    // Start is called before the first frame update
    void Start()
    {
        codes = System.Enum.GetValues(typeof(KeyCode));


    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode code in codes) {
            if (Input.GetKeyDown(code)) {
                EventLogger.Log(EventLog.EventCode.KeyDown(code));
            }
            if (Input.GetKeyUp(code)) {
                EventLogger.Log(EventLog.EventCode.KeyUp(code));
            }
        }
    }
}
