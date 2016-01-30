using UnityEngine;
using System.Collections;

public class TestBlinker : BlinkRoutine
{

    protected override IEnumerator BlinkPattern()
    {
        while (!complete)
        {
            foreach(COLORS c in Routine)
            {
                switch(c)
                {
                    case COLORS.RED:
                        blinkers[0].Blink();
                        break;
                    case COLORS.GREEN:
                        blinkers[1].Blink();
                        break;
                    case COLORS.BLUE:
                        blinkers[2].Blink();
                        break;
                    case COLORS.YELLOW:
                        blinkers[3].Blink();
                        break;
                }
                yield return PAUSE;
            }
            yield return ENDPAUSE;
        }
    }
}
