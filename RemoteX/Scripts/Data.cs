using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data // es como un enviroment
{
    public readonly string version = "V 0.8.2";
    public string savedPath = "/saved17.txt";
    public int palleteLength = 6;
    public int token_limit = 20;
    public float tokenPosInit_z = 45.0f;
    public float separeMagnitude = 10.0f;
    public float tokenSpeed = 5.0f; // velocidad inicial
    public float container_spawnCooldown = 0.8f; // velocidad inicial
    public Color defaultColor = new Color(1, 1, 1 ,1); // aceptado
    public float[] spawnRangeInit = { 0.5f, 0.9f };//0.5 1.0


    //estos tienes que tener un obj que posea la img y
    // luego volverla a prefab, es un peo, verlo luego, separarlo por carpetas bro...
    public string[] pathPowers =
    {
        "Time",//Default Power --> detiene el tiempo de el contenedor por un tiempo...
        "Multiplier",//Ganas x2 los puntos que metas por cierto tiempo...
        "Plus",//Añade 1 punto en capacidad extra y, cuesta mas usar el poder, basado en el inicial...
        "Shadows" // Acepta cualquier ficha por un pequeño tiempo, pone al container en blanco y el fondo en negro
        // TODO ["Reactive"] // --> permite eliminar aleatoriamente fichas
    };
    //se asigna la cantidad requerida para el uso de cada poder
    public int[] powersRequireds = { 10, 15, 4 , 8 };
    public float[] powerDelays = { 3.0f, 10.0f, 0.1f, 2f };

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
        "Mistery",
        "Star",
        "Shine",
        "Love",
        "Shield",
        "Sword",
        "Voyayer",
        "Forge",
        "Karma",
        "Bag"
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


    public Audios audios = new Audios();


    // Paths
    public string path_Img = "Images/";//GetComponent<Image>().sprite = sprite;
    public string path_Animation = "Animations/";//GetComponent<Animator>()
    public string path_Sfx= "Sfx/";//GetComponent<AudioSource>().??= ???;

    //Audio

    // PowerControllerName
    public string controllerName = "_Controller";// con esta vemos controlamos la animación

    //NO DESORGANIZAR NI CAMBIAR.. :

    //Hacemos con los tipos de store
    public string[] storeTypes ={"shapes","powers","palletes"};

    

}


//Audio path
public class Audios
{
    public readonly string bad_drop = "BadDrop";
    public readonly string check_drop = "CorrectDrop";
    public readonly string drag = "Drag";
    public readonly string drop = "Drop";
    public readonly string equip = "Equip";
}

/*
    cuando ganas algo nuevo te abre a auna pantalla de recompensa con el container y
    el token de la cosa, al arrastras y te da a entender que lo has ganado
*/

/*
 TODO
https://genial.guru/creacion-hogar/super-guia-para-combinar-colores-132905/

 */
