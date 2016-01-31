using UnityEngine;
using System.Collections;

public class PatternParent : MonoBehaviour {

    [SerializeField]
    GameObject[] patternPositions;

    /// <summary>
    /// Gets the gameobject for the given index
    /// </summary>
    /// <param name="index">index in the gameobject array</param>
    /// <returns></returns>
    public GameObject GetPositionParent(int index)
    {
        if (index > patternPositions.Length)
            return null;
        return patternPositions[index];
    }
}
