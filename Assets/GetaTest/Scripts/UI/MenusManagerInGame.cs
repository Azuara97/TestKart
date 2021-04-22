using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusManagerInGame : MonoBehaviour
{
    //Canvas
    private GameObject startPanel;
    private GameObject selectionPanel;
    private GameObject inGamePanel;
    private GameObject finishPanel;
    private GameObject successPanel;
    private GameObject failPanel;
    private GameObject loadingPanel;

    //Others
    private Text timeTextFinishPanel;
    private enum skinIndex { standard, variation1, variation2 }

    void Start()
    {
        setPanels();
        loadPlayerInfo();
        timeTextFinishPanel = successPanel.transform.GetChild(1).GetComponent<Text>();
    }

    void Update()
    {
        
    }

    //Sets
    private void setPanels()
    {
        setStartPanel();
        setSelectionPanel();
        setInGamePanel();
        setFinishPanel();
        setLoadingPanel();
    }
    private void setStartPanel()
    {
        startPanel = transform.GetChild(0).gameObject;
    }
    private void setSelectionPanel()
    {
        selectionPanel = transform.GetChild(1).gameObject;
    }
    private void setInGamePanel()
    {
        inGamePanel = transform.GetChild(2).gameObject;
    }
    private void setFinishPanel()
    {
        finishPanel = transform.GetChild(3).gameObject;
        successPanel = transform.GetChild(3).GetChild(0).gameObject;
        failPanel = transform.GetChild(3).GetChild(1).gameObject;
    }
    private void setLoadingPanel()
    {
        loadingPanel = transform.GetChild(4).gameObject;
    }

    //LoadFunctions
    private void loadPlayerInfo()
    {
        SaveLoad load = FindObjectOfType<SaveLoad>();
        PlayerInfo player = FindObjectOfType<PlayerInfo>();
        if (load && player)
        {
            load.loadPlayerInfo();

            switch (player.getCharacterIndex())
            {
                case (int)skinIndex.standard:
                    Instantiate(Resources.Load<GameObject>("KartPlayer1"), player.transform.position, player.transform.rotation);
                    break;
                case (int)skinIndex.variation1:
                    Instantiate(Resources.Load<GameObject>("KartPlayer2"), player.transform.position, player.transform.rotation);
                    break;
                case (int)skinIndex.variation2:
                    Instantiate(Resources.Load<GameObject>("KartPlayer3"), player.transform.position, player.transform.rotation);
                    break;
                default:
                    Instantiate(Resources.Load<GameObject>("KartPlayer1"), player.transform.position, player.transform.rotation);
                    break;
            }
        }
        else { Debug.Log("No se encontro SaveLoad o PlayerInfo"); }
    }

    //FinishFunctions
    public void activeFailPanel()
    {
        inGamePanel.SetActive(false);
        finishPanel.SetActive(true);
        successPanel.SetActive(false);
        failPanel.SetActive(true);
    }
    public void activeSuccessPanel(float time)
    {
        inGamePanel.SetActive(false);
        finishPanel.SetActive(true);
        successPanel.SetActive(true);
        failPanel.SetActive(false);
        timeTextFinishPanel.text = "Time: " + time.ToString();
    }

    //ButtonsFunctions
    private void spawnCharacter(int index, PlayerInfo player)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj)
        {
            Destroy(playerObj);
        }
        else { Debug.Log("No encontro Player"); }

        player.setCharacterIndex(index);
        switch (index)
        {
            case (int)skinIndex.standard:
                Instantiate(Resources.Load<GameObject>("KartPlayer1"), player.transform.position, player.transform.rotation);
                break;
            case (int)skinIndex.variation1:
                Instantiate(Resources.Load<GameObject>("KartPlayer2"), player.transform.position, player.transform.rotation);
                break;
            case (int)skinIndex.variation2:
                Instantiate(Resources.Load<GameObject>("KartPlayer3"), player.transform.position, player.transform.rotation);
                break;
            default:
                Instantiate(Resources.Load<GameObject>("KartPlayer1"), player.transform.position, player.transform.rotation);
                break;
        }
    }
    public void startGameButton()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(true);

        CamerasManager camerasManager = FindObjectOfType<CamerasManager>();
        MyGameManager gameManager = FindObjectOfType<MyGameManager>();
        if (camerasManager && gameManager)
        {
            camerasManager.activePlayerCamera();
            gameManager.setInGameBool(true);
        }
        else { Debug.Log("No encontro CamerasManager o MyGameManager"); }
    }
    public void selectionButton()
    {
        startPanel.SetActive(false);
        selectionPanel.SetActive(true);

        CamerasManager camerasManager = FindObjectOfType<CamerasManager>();
        if (camerasManager)
        {
            camerasManager.activeSelectionCamera();
        }
        else { Debug.Log("No encontro CamerasManager"); }
    }
    public void nextSkin()
    {
        PlayerInfo player = FindObjectOfType<PlayerInfo>();
        if (player)
        {
            int index = player.getCharacterIndex();
            index++;

            if (index > (int)skinIndex.variation2) { index = (int)skinIndex.standard; }

            spawnCharacter(index, player);
        }
        else { Debug.Log("No se encontro PlayerInfo"); }
    }
    public void previousSkin()
    {
        PlayerInfo player = FindObjectOfType<PlayerInfo>();
        if (player)
        {
            int index = player.getCharacterIndex();
            index++;

            if (index < (int)skinIndex.standard) { index = (int)skinIndex.variation2; }

            spawnCharacter(index, player);
        }
        else { Debug.Log("No se encontro PlayerInfo"); }
    }
    public void startGameButtonFromSelection()
    {
        selectionPanel.SetActive(false);
        inGamePanel.SetActive(true);

        CamerasManager camerasManager = FindObjectOfType<CamerasManager>();
        MyGameManager gameManager = FindObjectOfType<MyGameManager>();
        if (camerasManager && gameManager)
        {
            camerasManager.activePlayerCamera();
            gameManager.setInGameBool(true);
        }
        else { Debug.Log("No encontro CamerasManager o MyGameManager"); }
    }
    public void playAgainButton()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync(1);
    }
    public void mainMenuButton()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync(0);
    }
}
