using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameNameManger
{

    private static GameNameManger instance = null;

    static GameNameManger singleton()
    {
        if (instance == null)
        {
            instance = new GameNameManger();
        }
        return instance;
    }

    private GameNameManger()
    {
        words = new List<string>();
        string path = Path.Combine(Application.streamingAssetsPath, "words.txt");

        StreamReader file = new StreamReader(path);

        string contents = file.ReadToEnd();

        foreach (string word in contents.Split('|'))
        {
            words.Add(word);
        }
    }


    public static string Name()
    {
        return singleton().GetName();
    }




    private List<string> words;

    private string gameName = null;


    private string CreateName()
    {
        gameName = "";
        const int wordCount = 4;

        System.Random rnd = new System.Random();

        for (int i = 0; i < wordCount; ++i)
        {
            string word = words[rnd.Next(0, words.Count)];
            word = word.ToLower();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(word);
            sb[0] = char.ToUpper(sb[0]);
            word = sb.ToString();

            gameName += word;
        }

        return gameName;
    }

    public string GetName()
    {
        return gameName == null ? CreateName() : gameName;
    }

}
