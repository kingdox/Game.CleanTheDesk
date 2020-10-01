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

    [Header("Saved Data")]
    
    public int indexTokenImg; //--> default 0
    public int indexContainerImg; //--> default 1
    public int indexPower; //--> default 0
    
    public int highScore = 0;

    public int[] palleteStore;
    public int[] powersStore;
    public int[] shapesStore;


    [Space]
    [Header("To Manage")]
    public int lastScore;
    public Sprite spriteToken;
    public Sprite spriteContainer;
    public Sprite spritePower;//sprite o animation?

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

        // Set Default Things...
        SetDefault();

    }



    private void Start()
    {
        // start
        status = "start";
        StatusUpdate();
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
        indexTokenImg = 0; //--> default 0
        indexContainerImg = 1; //--> default 1
        indexPower = 0; //--> default 0

        SetStore();
    }


    private void SetStore()
    {
        foreach (var type in data.storeTypes)
        {
            switch (type)
            {
                case "shapes":
                    shapesStore = SetStoreOf(type);
                    break;
                case "powers":
                    powersStore = SetStoreOf(type);
                    break;
                case "palletes":
                    palleteStore = SetStoreOf(type);
                    break;
                default:
                    Debug.LogError("Has escrito algo mal...");
                    break;
            }

        }
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
                maxLength = data.pathpowers.Length;
                break;
            case "palletes": //not used yet
                maxLength = data.palletes.Length;
                break;
            default:
                Debug.LogError("Linea 110: Error con el Tipo de Store...?");
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

        spriteToken = Resources.Load<Sprite>( data.path_Img + data.pathShapes[indexTokenImg]);
        spriteContainer = Resources.Load<Sprite>(data.path_Img + data.pathShapes[indexContainerImg]);

        //Loading /Images/Name of powers with indexPower
        spritePower = Resources.Load<Sprite>(data.path_Img + data.pathpowers[indexPower]);
        //Debug.Log(Resources.Load<Sprite>(data.pathImg + data.pathShapes[0]));
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
        Debug.Log(File.Exists(path) + "on " + path);

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
        Debug.Log("Guardado");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + data.savedPath;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        DataStorage savedDataStorage = formatter.Deserialize(stream) as DataStorage;
        stream.Close();

        /// Aqui cargamos a DataPass la información
            indexPower = savedDataStorage.indexPower ;
            indexTokenImg = savedDataStorage.indexTokenImg ;
            indexContainerImg = savedDataStorage.indexContainerImg;

            highScore = savedDataStorage.highScore;

            shapesStore = savedDataStorage.shapesStore;
            powersStore = savedDataStorage.powersStore;
            palleteStore = savedDataStorage.palleteStore;

        ///________
    }
}
