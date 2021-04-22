using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    //PathVariables
    public GameSave save;
    const string folderName = "GameData";
    const string fileExtension = ".dat";
    const string fileName = "SaveGame";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //PathFunctions
    static void saveGameData(GameSave data, string path)
    {
        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Open(path, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }
    static GameSave loadGameData(string path)
    {
        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Open(path, FileMode.Open))
        {
            return (GameSave)binaryFormatter.Deserialize(fileStream);
        }
    }

    //Save
    public void saveGameInfo()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        GameInfo gameInfo = FindObjectOfType<GameInfo>();
        if (gameInfo)
        {
            save.totalRaces = gameInfo.getTotalRaces();
            save.bestTime = gameInfo.getBestTime();
        }
        else { Debug.Log("No encontro GameInfo"); }

        string dataPath = Path.Combine(folderPath, fileName + fileExtension);
        saveGameData(save, dataPath);
    }
    public void savePlayerInfo()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        PlayerInfo player = FindObjectOfType<PlayerInfo>();
        if (player)
        {
            save.skin = player.getCharacterIndex();
        }
        else { Debug.Log("No encontro PlayerInfo"); }

        string dataPath = Path.Combine(folderPath, fileName + fileExtension);
        saveGameData(save, dataPath);
    }

    //Loads
    public void loadGameInfo()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        string dataPath = Path.Combine(folderPath, fileName + fileExtension);

        if (File.Exists(dataPath))
        {
            save = loadGameData(dataPath);

            GameInfo gameInfo = FindObjectOfType<GameInfo>();
            if (gameInfo)
            {
                gameInfo.setTotalRaces(save.totalRaces);
                gameInfo.setBestTime(save.bestTime);
            }
            else { Debug.Log("No encontro GameInfo"); }
        }
        else
        {
            Debug.Log("No Game Saved");
        }
    }
    public void loadPlayerInfo()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        string dataPath = Path.Combine(folderPath, fileName + fileExtension);

        if (File.Exists(dataPath))
        {
            save = loadGameData(dataPath);

            PlayerInfo player = FindObjectOfType<PlayerInfo>();
            if (player)
            {
                player.setCharacterIndex(save.skin);
            }
            else { Debug.Log("No se encontro PlayerInfo"); }
        }
        else
        {
            Debug.Log("No Game Saved");
        }
    }
}
