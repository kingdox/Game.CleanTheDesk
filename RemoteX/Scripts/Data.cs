using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data // es como un enviroment
{
    public readonly string version = "V 0.4.0";
    public string savedPath = "/saved12.txt";




    //estos tienes que tener un obj que posea la img y
    // luego volverla a prefab, es un peo, verlo luego, separarlo por carpetas bro...
    public string[] pathpowers =
    {
        "Time",//Default Power
    };


    public string[] pathShapes = { //use pathImg
        "Circle",//Default IMG Token
        "Diamond",//Default IMG Container
        "Time",//Default IMG to Power
        "Spark",
        "Belt",
        "Arrow",
        "C",
        "T",
        "D",
        "Music"
    };


    public Color[] palletes =
    {
        new Color(1,0,0),
        new Color(1,0.5f,0),
        new Color(1,1,0),
        new Color(0,1,0),
        new Color(0,1,0.5f),
        new Color(0,1,1),
        new Color(0,0.5f,1),
        new Color(0,0,1),
        new Color(0.5f,0,1),
        new Color(1,0,0),
        new Color(1,0,1),
        new Color(1,0,0.5f),
        //--->Extras
        new Color(129, 60, 0 ),
        new Color(0, 129, 0 )
        //new Color(0, 0, 0 )
        //new Color(1, 1, 1 ),
    };



    // Paths
    public string path_Img = "Images/";//GetComponent<Image>().sprite = sprite;
    public string path_Animation = "Animations/";//GetComponent<>().??= ???;

    //Audio
    //Animated(powers?)



    public string[] storeTypes =
   {
        "shapes",
        "powers",
        "palletes"
    };

}


/*
    cuando ganas algo nuevo te abre a auna pantalla de recompensa con el container y
    el token de la cosa, al arrastras y te da a entender que lo has ganado
*/