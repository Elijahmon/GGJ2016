using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestRoom : MonoBehaviour {

    [SerializeField]
    protected int timeToComplete;
    [SerializeField]
    protected Text timerText;
    protected float currentTime;

    [SerializeField]
    protected Collider roomZoneCollider;

    protected bool isComplete;
    [SerializeField]
    protected RandomizedBlinkRoutine routine;

    /// <summary>
    /// Starts the timer for the test
    /// </summary>
    protected virtual void StartTimer()
    {
        currentTime = timeToComplete;
        StartCoroutine(UpdateTimer());
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
                timerText.text = string.Format("{0}:{1}:{2}", Mathf.Floor(currentTime / 3600), Mathf.Floor(currentTime / 60), currentTime % 60);
            }
            else
            {
                timerText.text = string.Format("{0}:{1}:{2}", 0,0,0);
            }
        }
    }
    /// <summary>
    /// Called when the timer runs out and the player has failed the test
    /// </summary>
    protected virtual void FailState()
    {

    }
}
