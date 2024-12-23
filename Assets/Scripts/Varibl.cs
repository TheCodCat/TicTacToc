using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Varibl
{
    public Texture2D Texture2D;
    public List<Vector2> vector2s = new List<Vector2>();

    public void Init()
    {
        for (int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                if (Texture2D.GetPixel(x, y) == Color.black)
                {
                    vector2s.Add(new Vector2(x, y));
                }
                else continue;
            }
        }

    }
}