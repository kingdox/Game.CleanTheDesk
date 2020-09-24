using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class DataPass : MonoBehaviour
{

    public static DataPass Instance;//Singleton....



    ////DataStorage && Data comunication
    //_____
    [Header("DataStorage && Data comunication")]

        // Saved File
        private readonly string savedPath = "/saved3.txt";

        //  Last Used
        public int indexPower = 0; //--> default 0
        public int indexTokenImg = 0; //--> default 0
        public int indexContainerImg = 1; //--> default 1

    // Unlockables
        public bool[] shapesUnlock;
        public bool[] powersUnlock;

        //  Score
        public int highScore = 0;
        public int lastScore;
    //______


    ///GameManager Comunication
    //____
    [Header("GameManager Comunication")]
        private Data data = new Data();

        public Sprite spriteToken;
        public Sprite spriteContainer;
        public Sprite spritePower;//sprite o animation?

        //public AudioClip Audio; //Musica ? TODO bruno ver

    //____


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



    public void StatusUpdate()
    {
        switch (status)
        {
            case "start":
                status = "ready";
                DataInit();//Primero carga o crea un archivo
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

        spriteToken = Resources.Load<Sprite>( data.pathImg + data.pathShapes[indexTokenImg]);
        spriteContainer = Resources.Load<Sprite>(data.pathImg + data.pathShapes[indexContainerImg]);

        Debug.Log(Resources.Load<Sprite>(data.pathImg + data.pathShapes[0]));
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
            shapesUnlock = savedDataStorage.shapesUnlock;
            powersUnlock = savedDataStorage.powersUnlock;
            highScore = savedDataStorage.highScore;
        ///________
            Debug.Log("Cargado");
    }
}
