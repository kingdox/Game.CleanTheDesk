using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class DataPass : MonoBehaviour
{

    public static DataPass Instance;//Singleton....
    private readonly Data data = new Data();
    private readonly ColorS colorService = new ColorS();

    [Header("Saved Data")]

    // played
    public int gamesPlayed = 0;

    //tutorial
    public bool tutorial = true;


    //Cambiar estos 2 a un array ?
    public int indexTokenImg; //--> default 0
    public int indexContainerImg; //--> default 1
    public int indexPower; //--> default 0
    public int[] indexPalletes; //---> default 0-n

    public int highScore = 0;

    public int[] palleteStore;
    public int[] powersStore;
    public int[] shapesStore;


    [Space]
    [Header("To Manage")]
    public Sprite spriteToken;
    public Sprite spriteContainer;

    public RuntimeAnimatorController controllerPower;

    public Color[] palletes;

    [Header("Status")]
    public string status;


    private void Awake()
    {
        //Singleton corroboration
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //NO cambiar orden..
        // Set Default Things...
        SetDefault(); // pone cosas por defecto
        status = "start"; // setea el estado de inicio
        StatusUpdate(); // actualiza constantemente el status...

    }
    private void Update()
    {

        if (status != "end") //load the img
        {
            StatusUpdate();
        }
    }



    private void SetDefault()
    {
        tutorial = true;
        gamesPlayed = 0;
        indexTokenImg = 0; //--> default 0
        indexContainerImg = 1; //--> default 1
        indexPower = 0; //--> default 0
        indexPalletes = new int[data.palleteLength]; //--> default 6
        palletes = new Color[data.palleteLength];
        for (int x = 0; x < indexPalletes.Length; x++)
        {
            indexPalletes[x] = x; //--> default color 0-5
            palletes[x] = data.palletes[x];
        }
        SetStore();
    }
    public void SetStore()
    {
        shapesStore = SetStoreOf("shapes");
        powersStore = SetStoreOf("powers");
        palleteStore = SetStoreOf("palletes");
    }


    private int[] SetStoreOf(string type)
    {

        int[] storeOf = new int[6];
        int maxLength;

        switch (type)
        {
            case "shapes":
                maxLength =  data.pathShapes.Length;
                break;
            case "powers": 
                maxLength = data.pathPowers.Length;
                break;
            case "palletes":
    
                storeOf = colorService.ReOrder(indexPalletes, palleteStore, data.palletes.Length );
                return storeOf;
                //maxLength = data.palletes.Length;
                //break;
            default:
                Debug.LogError("Error con el Tipo de Store...?");
                maxLength = storeOf.Length;
                break;
        }

        for (int i = 0; i < storeOf.Length; i++)
        {
            storeOf[i] = Random.Range(0, maxLength);
        }

        return storeOf;
    }
    public void StatusUpdate()
    {
        switch (status)
        {
            case "start":
                status = "loading";
                DataInit();//Primero carga o crea un archivo
                status = "ready";
                break;

            case "ready":// si el datapass esta listo por que creo o cargo algo entonces inicia
                status = "loading";
                LoadResources();
                break;
            case "loading":
                //....Wait
                break;
            default:
                break;
        }
    }



    public void LoadResources()
    {
        // Sprites
        spriteToken = Resources.Load<Sprite>( data.path_Img + data.pathShapes[indexTokenImg]);
        spriteContainer = Resources.Load<Sprite>(data.path_Img + data.pathShapes[indexContainerImg]);

        // Color
        for (int x = 0; x < indexPalletes.Length; x++)
        {
            palletes[x] = data.palletes[indexPalletes[x]];
        }

        // AnimatorController
        string powerName = data.pathPowers[indexPower];
        string animatorPath = data.path_Animation + powerName + "/" + powerName + data.controllerName;
        controllerPower = Resources.Load<RuntimeAnimatorController>(animatorPath);

        status = "end";
    }






    //___________DATA MANAGER


    /// <summary>
    /// Detecta el estado actual de tus datos, si tienes uno guardado lo carga
    /// Sino lo Crea....
    /// </summary>
    private void DataInit()
    {
        string path = Application.persistentDataPath + data.savedPath;
        //Debug.Log( "Exist? " + File.Exists(path) + " | on " + path);

        if (File.Exists(path))
        {
            //lo carga
            LoadData();
        }
        else
        {
            //lo crea
            SaveData(this);
        }
    }


    public void SaveData(DataPass dataPass)
    {
        string path = Application.persistentDataPath + data.savedPath;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        DataStorage dataS = new DataStorage(dataPass);

        formatter.Serialize(stream, dataS);
        stream.Close();
        //Debug.Log("Guardado");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + data.savedPath;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        DataStorage savedDataStorage = formatter.Deserialize(stream) as DataStorage;
        stream.Close();

            gamesPlayed = savedDataStorage.gamesPlayed;
            tutorial = savedDataStorage.tutorial;
        /// Aqui cargamos a DataPass la información
        ///

        indexPower = savedDataStorage.indexPower;
            indexTokenImg = savedDataStorage.indexTokenImg ;
            indexContainerImg = savedDataStorage.indexContainerImg;
            indexPalletes = savedDataStorage.indexPalletes;

            highScore = savedDataStorage.highScore;

            shapesStore = savedDataStorage.shapesStore;
            powersStore = savedDataStorage.powersStore;
            palleteStore = savedDataStorage.palleteStore;

        ///________
        ///
    }
}
