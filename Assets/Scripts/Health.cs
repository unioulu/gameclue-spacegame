using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;
    public Texture2D texture;
    public int textureSize = 50;
    public int texturePadding = 4;

    public void TakeDamage()
    {
        health -= 1;
    }

    private void OnGUI()
    {
        for (int i = 0; i < health; i++)
        {
            GUI.DrawTexture(new Rect(texturePadding + i * textureSize, Screen.height - textureSize - texturePadding, textureSize, textureSize), texture);
        }
    }
}
