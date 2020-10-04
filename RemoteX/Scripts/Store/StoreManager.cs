using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
        storeContainer.CreatePrefabs_Powers(datapass.powersStore); //TODO
        storeContainer.CreatePrefabs_Palletes(datapass.palleteStore);
        storeContainer.ChangeTo();
    }




    //__________________



    public void ChangesOn(int last_equipedValue,int storeIndex,string type,int equipedOfType)
    {
        //Hay que buscar del store escogido

        
        int last_storeValue = GetSelectedStoreValue(type, storeIndex);

        ChangeDataPass( last_equipedValue,  last_storeValue, storeIndex,  type,  equipedOfType);
    }


    private void ChangeDataPass(int last_equipedValue, int last_storeValue, int storeIndex, string type, int equipedOfType)
    {
        //Dependiendo del tipo
        switch (type)
        {
            case "shapes":

                if (equipedOfType == 0) //Token
                {
                    datapass.indexTokenImg = last_storeValue;
                }
                else //Container
                {
                    datapass.indexContainerImg = last_storeValue;
                }
                //Se cambia el valor que había en la tienda
                datapass.shapesStore[storeIndex] = last_equipedValue;

                break;
            case "powers":
                //TODO
                //datapass.indexPower = last_storeValue;
                //datapass.powersStore[storeIndex] = last_equipedValue;
                break;
            case "palletes":
                //aqui varía ya que en teoría va a  ser un array de colores...
                //TODO
                break;
            default:
                Debug.LogError("Type incorrecto");
                break;
        }


    }


    /// <summary>
    /// Tomas el valor de la posicion de la store
    /// </summary>
    /// <param name="type"></param>
    /// <param name="storeIndex"></param>
    /// <returns></returns>
    private int GetSelectedStoreValue(string type, int storeIndex)
    {

        int[] selected_Store = new int[0];

        switch (type)
        {
            case "shapes":
                selected_Store = datapass.shapesStore;
                break;
            case "powers":
                selected_Store = datapass.powersStore;

                break;
            case "palletes":
                selected_Store = datapass.palleteStore;
                break;
            default:
                Debug.LogError("Err, tipo incorrecto");
                break;
        }

        return selected_Store[storeIndex];//retorna el valor del store de ese sitio
    }

    private void ReturnHome()
    {
        datapass.SaveData(datapass);
        datapass.LoadData(); //--->TODO ver si con esto refresco als imagenes....

        Debug.Log("A casa");
        SceneManager.LoadScene(0);// te lleva al menú
    }

}