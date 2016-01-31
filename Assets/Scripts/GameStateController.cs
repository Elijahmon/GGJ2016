using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

    public enum GAME_STATE { MENU, INGAME, SUCCESS, FAIL };
    GAME_STATE currentState = GAME_STATE.MENU;

    private int currentDay = 1;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public int GetDay()
    {
        return currentDay;
    }

    public void ChangeState(GAME_STATE state)
    {
        currentState = state;
    }
    public void IncrementDay()
    {
        currentDay++;
    }
}
