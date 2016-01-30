using UnityEngine;
using System.Collections;

public class BlinkRoutine : MonoBehaviour {

    public enum COLORS { RED, GREEN, BLUE, YELLOW}

    [SerializeField]
    protected COLORS[] Routine;
    [SerializeField]
    protected BlinkHandler[] blinkers;

    public bool complete = false;

    protected WaitForSeconds ENDPAUSE = new WaitForSeconds(8);
    protected WaitForSeconds PAUSE = new WaitForSeconds(1);
    void Start()
    {
        StartCoroutine(BlinkPattern());
    }

    protected virtual IEnumerator BlinkPattern()
    {
        yield return null;
    }

    
}
