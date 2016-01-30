using UnityEngine;
using System.Collections;

public class PressureButton : MonoBehaviour {

    [SerializeField]
    Animator anim;

    bool isPressed = false;


	void OnTriggerEnter(Collider col)
    {
        //Debug.Log("trigger");
        isPressed = true;
        anim.SetBool("isPressed", isPressed);
        PressedActions();
    }
    void OnTriggerExit(Collider col)
    {
        isPressed = false;
        anim.SetBool("isPressed", isPressed);
    }
    /// <summary>
    /// PressedActions is used for individual buttons when the TriggerEnter is detected
    /// </summary>
    protected virtual void PressedActions()
    {
    }
}
