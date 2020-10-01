using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    //private Data data = new Data();
    private DataPass datapass = null;
    private StoreContainer storeContainer;
    private bool wantLoad = true;

    void Start()
    {
        datapass =  FindObjectOfType<DataPass>();
        storeContainer = FindObjectOfType<StoreContainer>();
    }

    void Update()
    {
        if (!!datapass && wantLoad)
        {
            wantLoad = false;
            LoadStore();
        }
    }


    /// <summary>
    /// Cargas todos los datos a mostrar en la store
    /// </summary>
    private void LoadStore()
    {
        storeContainer.CreatePrefabs_Shapes(datapass.shapesStore);
        storeContainer.CreatePrefabs_Powers(datapass.powersStore);
        storeContainer.CreatePrefabs_Palletes(datapass.palleteStore);
        storeContainer.ChangeTo();
    }

}



//Puedes usar ads para cargar denuevo la tienda? asi te salen otras cosas?