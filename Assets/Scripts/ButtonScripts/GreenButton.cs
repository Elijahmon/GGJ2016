using UnityEngine;
using System.Collections;

public class GreenButton : PressureButton
{

    void Awake()
    {
        buttonColor = COLORS.GREEN;
    }
    protected override void PressedActions()
    {
        base.PressedActions();
    }
}
