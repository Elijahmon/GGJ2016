using UnityEngine;
using System.Collections;

public class TestBlinker : BlinkRoutine
{

    protected override IEnumerator BlinkPattern()
    {
        while (!complete)
        {
            blinkers[0].Blink();
            yield return PAUSE;
            blinkers[1].Blink();
            yield return PAUSE;
            blinkers[0].Blink();
            yield return PAUSE;
            blinkers[1].Blink();
            yield return PAUSE;
            blinkers[0].Blink();
            yield return ENDPAUSE;
        }
    }
}
