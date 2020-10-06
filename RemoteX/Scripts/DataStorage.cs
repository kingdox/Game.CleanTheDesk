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
    public int[] indexPalletes;

    // Score
    public int highScore = 0;


    //Store
    public int[] shapesStore;
    public int[] powersStore;
    public int[] palleteStore;

    public DataStorage (DataPass dataPass) 
    {
        tutorial = true;

        indexPower = dataPass.indexPower;
        indexTokenImg = dataPass.indexTokenImg;
        indexContainerImg = dataPass.indexContainerImg;
        indexPalletes = dataPass.indexPalletes;

        highScore = dataPass.highScore;

        shapesStore = dataPass.shapesStore;
        powersStore = dataPass.powersStore;
        palleteStore = dataPass.palleteStore;

    }
}