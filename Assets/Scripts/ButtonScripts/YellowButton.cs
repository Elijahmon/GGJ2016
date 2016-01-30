using UnityEngine;
using System.Collections;

public class YellowButton : PressureButton
{

    void Awake()
    {
        buttonColor = COLORS.YELLOW;
    }
    protected override void PressedActions()
    {
        base.PressedActions();
    }
}
