using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data // es como un enviroment
{
    public readonly string version = "V 0.6.3";
    public string savedPath = "/saved16.txt";
    public int palleteLength = 6;
    public int token_limit = 25;
    public float tokenPosInit_z = 45.0f;
    public float separeMagnitude = 10.0f;
    public float tokenSpeed = 10.0f; // velocidad inicial
    //estos tienes que tener un obj que posea la img y
    // luego volverla a prefab, es un peo, verlo luego, separarlo por carpetas bro...
    public string[] pathPowers =
    {
        "Time",//Default Power
        "Multiplier"//Ganas x2 los puntosque metas
    };
    //se asigna la cantidad requerida para el uso de cada poder
    public int[] powersRequireds = { 30,4 };


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
        "Music",
        "Mistery"
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

    // PowerControllerName
    public string controllerName = "_Controller";// con esta vemos controlamos la animación

    //NO DESORGANIZAR NI CAMBIAR.. :

    //Hacemos con los tipos de store
    public string[] storeTypes ={"shapes","powers","palletes"};

    

}


/*
    cuando ganas algo nuevo te abre a auna pantalla de recompensa con el container y
    el token de la cosa, al arrastras y te da a entender que lo has ganado
*/

/*
 TODO
https://genial.guru/creacion-hogar/super-guia-para-combinar-colores-132905/

 */
