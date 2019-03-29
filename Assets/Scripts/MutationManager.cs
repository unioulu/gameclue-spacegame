using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationManager
{
    private static MutationManager instance = null;


    private string mutationName = "BaseGameScene";

    static MutationManager singleton()
    {
        if (instance == null)
        {
            instance = new MutationManager();
        }
        return instance;
    }

    private MutationManager()
    {

    }


    public static string MutationName()
    {
        return singleton().mutationName;
    }

    public static void SetMutationName(string tobe)
    {
        singleton().mutationName = tobe;
    }
}
