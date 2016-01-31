using UnityEngine;
using System.Collections;

public class TestRoom2 : TestRoom
{

    [SerializeField]
    protected WallPattern pattern;

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
            Debug.Log("Starting Test");
            StartTimer();
            started = true;
            pattern.PopulatePattern();
        }
    }
    protected override void RedPressed()
    {

        if (pattern.GetColorAt(completionIndex) == 0)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= pattern.GetLength())
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

        if (pattern.GetColorAt(completionIndex) == 1)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= pattern.GetLength())
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

        if (pattern.GetColorAt(completionIndex) == 2)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= pattern.GetLength())
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

        if (pattern.GetColorAt(completionIndex) == 3)
        {
            completionIndex++;
            //Debug.Log("Correct");
            if (completionIndex >= pattern.GetLength())
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
        //Debug.Log("Success");
    }
    protected override void FailState()
    {
        base.FailState();
        //Debug.Log("Fail");
    }

}
