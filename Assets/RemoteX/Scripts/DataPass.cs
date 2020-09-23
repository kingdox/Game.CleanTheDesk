using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class DataPass : MonoBehaviour
{
    ////DataStorage && Data comunication
    //_____
    [Header("DataStorage && Data comunication")]

        // Saved File
        private readonly string savedPath = "/saved1.txt";

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

        public Sprite shapeToken;
        public Sprite shapeContainer;
        public Sprite shapePower;

        //public AudioClip Audio; //Musica ? TODO bruno ver
        
    //____

    //no se inician las cosas hasta que se cargue los datos
    public bool loadingData = true; //se inicia en true hasta que termine de cargar



    private void Start()
    {
        LoadResources();
    }





    public void LoadResources()
    {

        shapeToken  = Resources.Load<Sprite>( data.pathImg + data.pathShapes[indexTokenImg]);

        Debug.Log(Resources.Load<Sprite>(data.pathImg + data.pathShapes[0]));

    }



    public void DataInit()
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
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + savedPath;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        DataStorage savedDataStorage = formatter.Deserialize(stream) as DataStorage;
        stream.Close();

        /// Aqui cargamos a DataPass la información
            savedDataStorage.indexPower = indexPower;
            savedDataStorage.indexTokenImg = indexTokenImg;
            savedDataStorage.indexContainerImg = indexContainerImg;

            savedDataStorage.shapesUnlock = shapesUnlock;
            savedDataStorage.powersUnlock = powersUnlock;

            savedDataStorage.highScore = highScore;
        ///________

    }
}
