using UnityEngine;
using System.Collections;

public class BlinkRoutine : MonoBehaviour {

    public enum COLORS { RED, GREEN, BLUE, YELLOW}

    [SerializeField]
    protected COLORS[] routine;
    [SerializeField]
    protected BlinkHandler redBlinker;
    [SerializeField]
    protected BlinkHandler greenBlinker;
    [SerializeField]
    protected BlinkHandler blueBlinker;
    [SerializeField]
    protected BlinkHandler yellowBlinker;

    public bool complete = false;

    protected WaitForSeconds ENDPAUSE = new WaitForSeconds(5);
    protected WaitForSeconds PAUSE = new WaitForSeconds(1);
    void Start()
    {
        StartCoroutine(BlinkPattern());
    }

    protected virtual IEnumerator BlinkPattern()
    {
        while (!complete)
        {
            
            foreach (COLORS c in routine)
            {
                switch (c)
                {
                    case COLORS.RED:
                        redBlinker.Blink();
                        break;
                    case COLORS.GREEN:
                        greenBlinker.Blink();
                        break;
                    case COLORS.BLUE:
                        blueBlinker.Blink();
                        break;
                    case COLORS.YELLOW:
                        yellowBlinker.Blink();
                        break;
                }
                yield return PAUSE;
            }
            yield return ENDPAUSE;
        }
    }
    /// <summary>
    /// Retrieves the int ID of the color at the given index
    /// </summary>
    /// <param name="index">Index in the array to check</param>
    /// <returns></returns>
    public int GetColorAt(int index)
    {
        return (int)routine[index];
    }
    /// <summary>
    /// Retrieves length of color array
    /// </summary>
    /// <returns></returns>
    public int GetLength()
    {
        return routine.Length;
    }
    
}
