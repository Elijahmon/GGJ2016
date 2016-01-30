using UnityEngine;
using System.Collections;

public class RandomizedBlinkRoutine : BlinkRoutine {


    void Awake()
    {
        CreateRandomRoutine();
    }
    void CreateRandomRoutine()
    {
        routine = new COLORS[8];
        for(int i = 0; i < routine.Length; i++)
        {
            routine[i] = (COLORS)Random.Range(0, 3);
        }
    }

    protected override IEnumerator BlinkPattern()
    {
        return base.BlinkPattern();
    }
}
