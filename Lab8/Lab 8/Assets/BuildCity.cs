using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int mapWidth = 300;
    public int mapHeight = 300;
    float buildingFootprint = 3.5f;

    void Start()
    {
        float seed = Random.RandomRange(0, 100);
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);
                float result = Mathf.PerlinNoise(w / 50.0f + seed, h / 40.0f + seed) * 100;
                int i;

                if (result < 30) i = 0;
                else if (result < 35) i = 1;
                else if (result < 45) i = 6;
                else if (result < 57) i = 5;
                else if (result < 70) i = 4;
                else if (result < 84) i = 3;
                else if (result < 90) i = 2;
                else i = 1;

                Instantiate(buildings[i], pos, Quaternion.identity);
                if (i > 1) Instantiate(buildings[1], pos, Quaternion.identity);
            }
        }
    }
}
