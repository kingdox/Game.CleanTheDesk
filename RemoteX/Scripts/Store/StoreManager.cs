using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    //private Data data = new Data();
    private DataPass datapass = null;
    private StoreContainer storeContainer;
    private DetectorHome detectorHome;
    private bool wantLoad = true;


    void Start()
    {
        datapass =  FindObjectOfType<DataPass>();
        storeContainer = FindObjectOfType<StoreContainer>();
        detectorHome = FindObjectOfType<DetectorHome>();
    }

    void Update()
    {
        if (!!datapass && wantLoad)
        {
            wantLoad = false;
            LoadStore();
        }

        if (detectorHome.wantGoHome)
        {
            ReturnHome();
        }
    }


    /// <summary>
    /// Cargas los datos a mostrar en la store
    /// </summary>
    private void LoadStore()
    {
        storeContainer.CreatePrefabs_Shapes(datapass.shapesStore);
        //storeContainer.CreatePrefabs_Powers(datapass.powersStore);
        storeContainer.CreatePrefabs_Palletes(datapass.palleteStore);
        storeContainer.ChangeTo();
    }



    /// <summary>
    /// Hacemos un proceso de regreso a casa, debemos guardar los cambios
    /// </summary>
    private void ReturnHome()
    {

        datapass.SaveData(datapass);

        Debug.Log("A casa");
        SceneManager.LoadScene(0);// te lleva al menú
    }

}



//Puedes usar ads para cargar denuevo la tienda? asi te salen otras cosas?