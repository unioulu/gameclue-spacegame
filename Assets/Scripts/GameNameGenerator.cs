using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameNameGenerator : MonoBehaviour
{

    private List<string> words;

    private string gameName = null;

    private void Start()
    {
        words = new List<string>();
        string path = Path.Combine(Application.streamingAssetsPath, "words.txt");

        StreamReader file = new StreamReader(path);

        string contents = file.ReadToEnd();

        foreach (string word in contents.Split('|')) {
            words.Add(word);
        }

    }

    private string CreateName()
    {
        gameName = "";
        const int wordCount = 4;

        for (int i = 0; i < wordCount; ++i)
        {
            string word = words[Random.Range(0, words.Count)];
            word = word.ToLower();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(word);
            sb[0] = char.ToUpper(sb[0]);
            word = sb.ToString();

            gameName += word;
        }

        return gameName;
    }

    public string Name()
    {
        return gameName == null ? CreateName() : gameName;
    }

}
