using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataStorage
{

    // Tutorial 
    public bool tutorial = false;

    // Last Used
    public int indexPower = 0;
    public int indexTokenImg = 0;
    public int indexContainerImg = 1;

    // Unlockables
    public bool[] shapesUnlock;
    public bool[] powersUnlock;

    // Score
    public int highScore = 0;


    public DataStorage (DataPass dataPass) 
    {
        tutorial = true;

        indexPower = dataPass.indexPower;
        indexTokenImg = dataPass.indexTokenImg;
        indexContainerImg = dataPass.indexContainerImg;

        shapesUnlock = dataPass.shapesUnlock;
        powersUnlock = dataPass.powersUnlock;

        highScore = dataPass.highScore;

    }
}