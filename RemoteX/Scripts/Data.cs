using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data // es como un enviroment
{

    //estos tienes que tener un obj que posea la img y luego volverla a prefab, es un peo, verlo luego, separarlo por carpetas bro...
    public string[] Pathpowers =
    {
        "Time",//Default Power
    };


    public string[] pathShapes = { //use pathImg
        "Circle",//Default IMG Token
        "Diamond",//Default IMG Container
        "Time",//Default IMG to Power
        "Spark",
        "Belt"


    };





    // Paths
    public string pathImg = "Images/";//GetComponent<Image>().sprite = sprite;
    public string pathAnimation = "Animations/";//GetComponent<>().??= ???;

    //Audio
    //Animated(powers?)
}

//poner las letras en otro lado?, es un extra especial :9