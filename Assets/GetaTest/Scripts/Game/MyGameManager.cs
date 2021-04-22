using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    //GameVariables
    private bool inGame = false;
    [SerializeField]
    private float time = 10f;
    public Text timeText;

    void Start()
    {
        
    }

    void Update()
    {
        if (inGame)
        {
            time -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(time % 60);
            float mili = time % 1 * 100;
            timeText.text = string.Format("{0:00}:{1:00}", seconds, mili);

            if (time <= 0f)
            {
                inGame = false;
                time = 10f;
                MenusManagerInGame menusManager = FindObjectOfType<MenusManagerInGame>();
                SaveLoad save = FindObjectOfType<SaveLoad>();
                if (menusManager && save)
                {
                    menusManager.activeFailPanel();
                    save.savePlayerInfo();
                }
                else { Debug.Log("No encontro MenusManagerInGame o SaveLoad"); }
            }
        }
    }

    //GameFunctions
    public void addExtraTime(float extraTime)
    {
        time += extraTime;
    }

    //Sets
    public void setInGameBool(bool value)
    {
        inGame = value;
    }

    //Gets
    public bool getInGameBool()
    {
        return inGame;
    }
    public float getTime()
    {
        return time;
    }
}
