using UnityEngine;
using System.Collections;

public class RandomizedWallPattern : WallPattern {

	void Awake()
    {
        CreateRandomPattern();
    }
    
    void CreateRandomPattern()
    {
        pattern = new COLORS[6];
        for (int i = 0; i < pattern.Length; i++)
        {
            pattern[i] = (COLORS)Random.Range(0, 3);
        }
    }
}
