using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameNameGenerator : MonoBehaviour
{

    private List<string> words;

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

    public string CreateName()
    {
        string name = "";
        const int wordCount = 4;

        for (int i = 0; i < wordCount; ++i)
        {
            string word = words[Random.Range(0, words.Count)];
            word = word.ToLower();
            System.Text.StringBuilder sb = new System.Text.StringBuilder(word);
            sb[0] = char.ToUpper(sb[0]);
            word = sb.ToString();

            name += word;
        }

        return name;
    }

}
