using UnityEngine;
using System.Collections;

public class TestRoom1 : TestRoom
{

    [SerializeField]
    protected RandomizedBlinkRoutine routine;

    [SerializeField]
    RedButton redButton;
    [SerializeField]
    GreenButton greenButton;
    [SerializeField]
    BlueButton blueButton;
    [SerializeField]
    YellowButton yellowButton;


    public override void StartTest()
    {
        if (!started)
        {
            //Debug.Log("Starting Test");
            StartTimer();
            started = true;
        }
    }
    protected override void RedPressed()
    {
        if(routine.GetColorAt(completionIndex) == 0)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= routine.GetLength())
            {
                SuccessState();
            }
        }
        else
        {
            //Debug.Log("Incorrect");
            completionIndex = 0;
        }
    }
    protected override void GreenPressed()
    {
        if (routine.GetColorAt(completionIndex) == 1)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= routine.GetLength())
            {
                SuccessState();
            }
        }
        else
        {
            //Debug.Log("Incorrect");
            completionIndex = 0;
        }
    }
    protected override void BluePressed()
    {
        if (routine.GetColorAt(completionIndex) == 2)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= routine.GetLength())
            {
                SuccessState();
            }
        }
        else
        {
            //Debug.Log("Incorrect");
            completionIndex = 0;
        }
    }
    protected override void YellowPressed()
    {
        if (routine.GetColorAt(completionIndex) == 3)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= routine.GetLength())
            {
                SuccessState();
            }
        }
        else
        {
            //Debug.Log("Incorrect");
            completionIndex = 0;
        }
    }

    protected override void SuccessState()
    {
        base.SuccessState();
        routine.complete = true;
        //Debug.Log("Success");
    }
    protected override void FailState()
    {
        base.FailState();
        routine.complete = true;
        //Debug.Log("Fail");
    }

}
