using UnityEngine;
using System.Collections;

public class RandomizedWallPattern : WallPattern {

    [SerializeField]
    protected int patternLength;
	void Awake()
    {
        CreateRandomPattern();
    }
    
    void CreateRandomPattern()
    {
        pattern = new COLORS[patternLength];
        for (int i = 0; i < pattern.Length; i++)
        {
            pattern[i] = (COLORS)Random.Range(0, 4);
        }
    }
}
