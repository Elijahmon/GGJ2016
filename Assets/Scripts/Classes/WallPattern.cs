using UnityEngine;
using System.Collections;

public class WallPattern : MonoBehaviour {


    public enum COLORS { RED, GREEN, BLUE, YELLOW }

    [SerializeField]
    protected COLORS[] pattern;

    [SerializeField]
    protected GameObject redObjectPrefab;
    [SerializeField]
    protected GameObject greenObjectPrefab;
    [SerializeField]
    protected GameObject blueObjectPrefab;
    [SerializeField]
    protected GameObject yellowObjectPrefab;

    [SerializeField]
    protected PatternParent[] patternParents;

    /// <summary>
    /// Retrieves the int ID of the color at the given index
    /// </summary>
    /// <param name="index">Index in the array to check</param>
    /// <returns></returns>
    public int GetColorAt(int index)
    {
        return (int)pattern[index];
    }
    /// <summary>
    /// Retrieves length of color array
    /// </summary>
    /// <returns></returns>
    public int GetLength()
    {
        return pattern.Length;
    }

    /// <summary>
    /// Populates all child pattern objects
    /// </summary>
    public virtual void PopulatePattern()
    {
        for(int i = 0; i < patternParents.Length; i++)
        {
            for(int j = 0; j < pattern.Length; j++)
            {
                GameObject spawnPoint = patternParents[i].GetPositionParent(j);
                switch(pattern[j])
                {
                    case COLORS.RED:
                        GameObject redSpawn = (GameObject)Instantiate(redObjectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        redSpawn.transform.parent = spawnPoint.transform;
                        redSpawn.transform.localScale = Vector3.one;
                        break;
                    case COLORS.GREEN:
                        GameObject greenSpawn = (GameObject)Instantiate(greenObjectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        greenSpawn.transform.parent = spawnPoint.transform;
                        greenSpawn.transform.localScale = Vector3.one;
                        break;
                    case COLORS.BLUE:
                        GameObject blueSpawn = (GameObject)Instantiate(blueObjectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        blueSpawn.transform.parent = spawnPoint.transform;
                        blueSpawn.transform.localScale = Vector3.one;
                        break;
                    case COLORS.YELLOW:
                        GameObject yellowSpawn = (GameObject)Instantiate(yellowObjectPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        yellowSpawn.transform.parent = spawnPoint.transform;
                        yellowSpawn.transform.localScale = Vector3.one;
                        break;
                }
            }
        }
    }
}
