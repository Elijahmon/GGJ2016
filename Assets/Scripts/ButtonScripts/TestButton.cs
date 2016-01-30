using UnityEngine;
using System.Collections;

public class TestButton : PressureButton {

    protected override void PressedActions()
    {
        Debug.Log("Test Button Pressed");
    }
}
