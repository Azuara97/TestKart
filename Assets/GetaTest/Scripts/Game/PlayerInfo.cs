using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //PlayerVariables
    private int characterIndex;

    //Set
    public void setCharacterIndex(int skin)
    {
        characterIndex = skin;
    }

    //Get
    public int getCharacterIndex()
    {
        return characterIndex;
    }
}
