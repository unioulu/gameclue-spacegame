using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueManager
{

    private static CueManager instance = null;


    private bool hasCues = true;

    static CueManager singleton()
    {
        if (instance == null)
        {
            instance = new CueManager();
        }
        return instance;
    }

    private CueManager()
    {
        
    }


    public static bool HasCues()
    {
        return singleton().hasCues;
    }

    public static void SetCues(bool tobe)
    {
        singleton().hasCues = tobe;
    }

}
