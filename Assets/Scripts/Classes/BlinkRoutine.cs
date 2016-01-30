using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlinkRoutine : MonoBehaviour {

    [SerializeField]
    protected List<BlinkHandler> blinkers;

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
