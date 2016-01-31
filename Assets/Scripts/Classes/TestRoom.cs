using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestRoom : MonoBehaviour {

    [SerializeField]
    protected int timeToComplete;
    [SerializeField]
    protected Text timerText;
    protected int currentTime;

    protected bool isComplete;
    protected bool started;
    const string timerFormat = "00.##";

    protected int completionIndex = 0;


    /// <summary>
    /// Starts the timer for the test
    /// </summary>
    protected virtual void StartTimer()
    {
        currentTime = timeToComplete;
        StartCoroutine(UpdateTimer());
    }
    /// <summary>
    /// Starts the timer and logic for the test
    /// </summary>
    public virtual void StartTest()
    {
        
    }
    /// <summary>
    /// Updates the Timer in a Coroutine. Also handles failstate
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator UpdateTimer()
    {
        while (!isComplete)
        {
            if (currentTime > 0)
            {
                yield return new WaitForSeconds(1);
                currentTime--;
                timerText.text = string.Format("{0}:{1}:{2}", Mathf.FloorToInt(currentTime / 3600).ToString(timerFormat), Mathf.FloorToInt(currentTime / 60).ToString(timerFormat), (currentTime % 60).ToString(timerFormat));
            }
            else
            {
                timerText.text = string.Format("{0}:{1}:{2}", 0,0,0);
                FailState();
            }
        }
        yield return null;
    }
    /// <summary>
    /// Called when the timer runs out and the player has failed the test
    /// </summary>
    protected virtual void FailState()
    {
        isComplete = true;
        GameObject.FindObjectOfType<GameStateController>().GetComponent<GameStateController>().FailedTest();
    }
    protected virtual void SuccessState()
    {
        isComplete = true;
    }

    public virtual void ButtonPressed(int colorID)
    {
        if (isComplete)
            return;
        switch(colorID)
        {
            case 0:
                RedPressed();
                break;
            case 1:
                GreenPressed();
                break;
            case 2:
                BluePressed();
                break;
            case 3:
                YellowPressed();
                break;
        }
    }

    protected virtual void RedPressed()
    {

    }
    protected virtual void GreenPressed()
    {

    }
    protected virtual void BluePressed()
    {

    }
    protected virtual void YellowPressed()
    {

    }

}
