using UnityEngine;
using System.Collections;

public class BlueButton : PressureButton {

    void Awake()
    {
        buttonColor = COLORS.BLUE;
    }
    protected override void PressedActions()
    {
        base.PressedActions();
    }

}
