using UnityEngine;
using System.Collections;

public class RedButton : PressureButton {


    void Awake()
    {
        buttonColor = COLORS.RED;
    }
    protected override void PressedActions()
    {
        base.PressedActions();
    }
}
