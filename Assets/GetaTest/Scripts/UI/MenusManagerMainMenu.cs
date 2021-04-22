using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusManagerMainMenu : MonoBehaviour
{
    //Canvas
    private GameObject mainMenuPanel;
    private GameObject loadingPanel;

    void Start()
    {
        setMainMenuCanvas();
        loadGame();
        updateTextsStart();
    }

    //StartFunctions
    private void setMainMenuCanvas()
    {
        mainMenuPanel = transform.GetChild(0).gameObject;
        loadingPanel = transform.GetChild(1).gameObject;
    }
    private void loadGame()
    {
        SaveLoad load = FindObjectOfType<SaveLoad>();
        if (load)
        {
            load.loadGameInfo();
        }
        else { Debug.Log("No encontro SaveLoad"); }
    }
    private void updateTextsStart()
    {
        Text totalRaces = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
        Text bestTime = transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Text>();
        GameInfo gameInfo = FindObjectOfType<GameInfo>();
        if(totalRaces && bestTime && gameInfo)
        {
            totalRaces.text = "Total Races: " + gameInfo.getTotalRaces().ToString();
            bestTime.text = "Best Time: " + gameInfo.getBestTime().ToString();
        }
        else { Debug.Log("No encontro algun text o GameInfo"); }
    }

    //ButtonsFunctions
    public void playGameButton()
    {
        mainMenuPanel.SetActive(false);
        loadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }
    public void quitGameButton()
    {
        Application.Quit();
    }
}
