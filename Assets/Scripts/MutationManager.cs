using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MutationManager
{
    private static MutationManager instance = null;


    private string mutationName = "BaseGameScene";

    private string baseMutationName = "BaseGameScene";
    private string fullGameMutationName = "FullGameScene";
    private string[] mutations = { "PointGameScene", "MovementGameScene", "ShootGameScene", "InputGameScene" };

    private string[] orderedMutations = null;
    private int indexOfMutation = 0;

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

        System.Random rnd = new System.Random();
        new UnityEngine.Random();
        orderedMutations = mutations.OrderBy(x => rnd.Next()).ToArray();

    }


    public static string MutationName()
    {
        return singleton().mutationName;
    }

    public static void SetMutationName(string tobe)
    {
        singleton().mutationName = tobe;
    }

    public static string FullGameMutation()
    {
        return singleton().fullGameMutationName;
    }

    public static string GotoNextMutation()
    {
        string name = singleton().GetNextMutation();
        SetMutationName(name);
        return name;
    }

    private string GetNextMutation()
    {
        if (indexOfMutation < orderedMutations.Length)
        {
            string name = orderedMutations[indexOfMutation];
            indexOfMutation++;
            return name;
        }
        return baseMutationName;
    }
}
