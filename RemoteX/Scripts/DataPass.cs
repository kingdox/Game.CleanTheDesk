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

    // Saved File
    private readonly string savedPath = "/saved7.txt";

    [Header("Saved Data")]
    
    public int indexTokenImg; //--> default 0
    public int indexContainerImg; //--> default 1
    public int indexPower; //--> default 0
    
    public int highScore = 0;
    
    public int[] lastStore = new int[8];//La creamos aquí
    public string storeType = "shapes";//shapes, powers, ¿ colors ?



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
            
    }



    private void Start()
    {
        SetDefault();
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
        lastStore = new int[8];
        int count = 0;
        int maxLength;
        switch (storeType)
        {
            case "shapes":
                maxLength =  data.pathShapes.Length;
                break;
            case "powers":
                maxLength = data.pathpowers.Length;
                break;
            case "colors": //not used yet
                maxLength = data.palletes.Length;
                break;
            default:
                maxLength = 8;
                break;
        }

        for (int i = 0; i < lastStore.Length; i++)
        {
            lastStore[i] = Random.Range(0, maxLength);
        }

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
        string path = Application.persistentDataPath + savedPath;
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
        string path = Application.persistentDataPath + savedPath;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        DataStorage data = new DataStorage(dataPass);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Guardado");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + savedPath;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        DataStorage savedDataStorage = formatter.Deserialize(stream) as DataStorage;
        stream.Close();

        /// Aqui cargamos a DataPass la información
            indexPower = savedDataStorage.indexPower ;
            indexTokenImg = savedDataStorage.indexTokenImg ;
            indexContainerImg = savedDataStorage.indexContainerImg;
            highScore = savedDataStorage.highScore;

            lastStore = savedDataStorage.lastStore;
            storeType = savedDataStorage.storeType;
        ///________
    }
}
