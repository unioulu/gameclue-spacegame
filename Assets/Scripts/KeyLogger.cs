using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogger : MonoBehaviour
{

    private List<KeyCode> codes;

    // Start is called before the first frame update
    void Start()
    {
        codes = new List<KeyCode>();
        codes.Add(KeyCode.LeftArrow);
        codes.Add(KeyCode.RightArrow);
        codes.Add(KeyCode.UpArrow);
        codes.Add(KeyCode.DownArrow);
        codes.Add(KeyCode.J);
        codes.Add(KeyCode.I);
        codes.Add(KeyCode.K);
        codes.Add(KeyCode.L);
        codes.Add(KeyCode.Space);
        codes.Add(KeyCode.W);
        codes.Add(KeyCode.A);
        codes.Add(KeyCode.S);
        codes.Add(KeyCode.D);


    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(code))
            {
                EventLogger.Log(EventLog.EventCode.KeyDown(code));
            }
            if (Input.GetKeyUp(code))
            {
                EventLogger.Log(EventLog.EventCode.KeyUp(code));
            }
        }
        /*foreach (KeyCode code in codes)
        {
            if (Input.GetKeyDown(code)) {
                EventLogger.Log(EventLog.EventCode.KeyDown(code));
            }
            if (Input.GetKeyUp(code))
            {
                EventLogger.Log(EventLog.EventCode.KeyUp(code));
            }
        }*/
    }
}
