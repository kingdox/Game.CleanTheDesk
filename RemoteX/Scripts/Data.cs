using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data // es como un enviroment
{
    public readonly string version = "V 0.4.8";
    public string savedPath = "/saved15.txt";

    public int palleteLength = 6;


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
        //new Color(1,0,0), --> repetido
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



    //NO DESORGANIZAR NI CAMBIAR.. :


    //Hacemos con los tipos de animación
    //Nota: por como veo, el componente 'Animator' solo pide el 'controller', así que podríamos obviar el 'Animation' en el uso de scripts, a no ser que quisieramos repetir configuraciones?
    public string controllerName = "_Controller";// con esta vemos por al del tipo...
    public string[] animationType =
    {
        "_Animation",
        "_Controller"
    };

    //Hacemos con los tipos de store
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