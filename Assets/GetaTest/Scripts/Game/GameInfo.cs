using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    //GameVariables
    [SerializeField]
    private float bestTime;
    [SerializeField]
    private int totalRaces;

    //GameFunctions
    public void addFinishedRace(int number)
    {
        totalRaces += number;
    }
    public void compareTimes(float time)
    {
        if (time > bestTime)
        {
            bestTime = time;
        }
    }

    //Sets
    public void setTotalRaces(int races)
    {
        totalRaces = races;
    }
    public void setBestTime(float time)
    {
        bestTime = time;
    }

    //Gets
    public int getTotalRaces()
    {
        return totalRaces;
    }
    public float getBestTime()
    {
        return bestTime;
    }
}
