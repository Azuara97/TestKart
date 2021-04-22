using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MyGameManager gameManager = FindObjectOfType<MyGameManager>();
            MenusManagerInGame menusManager = FindObjectOfType<MenusManagerInGame>();
            GameInfo gameInfo = FindObjectOfType<GameInfo>();
            SaveLoad save = FindObjectOfType<SaveLoad>();
            if (gameManager && menusManager && gameInfo && save)
            {
                if (gameManager.getTime() > 0)
                {
                    gameManager.setInGameBool(false);
                    menusManager.activeSuccessPanel(gameManager.getTime());
                    gameInfo.compareTimes(gameManager.getTime());
                    gameInfo.addFinishedRace(1);
                    save.saveGameInfo();
                    save.savePlayerInfo();
                }
            }
            else { Debug.Log("No encontro GameManager o MenusManagerInGame o GameInfo o SaveLoad"); }
        }
    }
}
