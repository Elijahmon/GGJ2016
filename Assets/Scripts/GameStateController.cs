using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStateController : MonoBehaviour {

    public enum GAME_STATE { MENU, INGAME, SUCCESS, FAIL };
    GAME_STATE currentState = GAME_STATE.MENU;

    private int currentDay = 1;

    [SerializeField]
    GameObject StartMenu;
    [SerializeField]
    GameObject DayUI;
    [SerializeField]
    Text days;
    [SerializeField]
    GameObject SuccessUI;
    [SerializeField]
    GameObject FailUI;
    [SerializeField]
    GameObject CreditsUI;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 0:
                currentState = GAME_STATE.MENU;
                DisplayStartMenu();
                break;
            case 1:
                currentState = GAME_STATE.INGAME;
                StartCoroutine(DisplayDay());
                currentDay++;
                break;
            case 2:
                currentState = GAME_STATE.SUCCESS;
                break;
            case 3:
                currentState = GAME_STATE.FAIL;
                StartCoroutine(ResetFail());
                break;


        }
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
    IEnumerator DisplayDay()
    {
        DayUI.SetActive(true);
        days.text = "Day " + currentDay;
        Image ui = DayUI.GetComponent<Image>();
        yield return new WaitForSeconds(2);
        while (ui.color.a > 0.1f)
        {
            ui.color = new Color(ui.color.r, ui.color.g, ui.color.b, ui.color.a - 0.05f);
            yield return new WaitForSeconds(0.1f);
        }
        DayUI.SetActive(false);
        ui.color = new Color(ui.color.r, ui.color.g, ui.color.b, 0.8f);
        yield return null;
    }
    IEnumerator ResetFail()
    {
        FailUI.SetActive(true);
        yield return new WaitForSeconds(5);
        FailUI.SetActive(false);
        LoadMaze();
    }
    void DisplayStartMenu()
    {
        StartMenu.SetActive(true);
    }
    void HideStartMenu()
    {
        StartMenu.SetActive(false);
    }

    public void StartButtonPressed()
    {
        //  StartCoroutine(LoadMazeAsync());
        SceneManager.LoadSceneAsync(1);
        HideStartMenu();

    }
    public void QuitButtonPressed()
    {
        Application.Quit();
    }
    public void CreditsButtonPressed()
    {
        StartMenu.SetActive(false);
        CreditsUI.SetActive(true);
    }
    public void BackButtonPresed()
    {
        CreditsUI.SetActive(false);
        StartMenu.SetActive(true);
    }
    void LoadMaze()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void FailedTest()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
