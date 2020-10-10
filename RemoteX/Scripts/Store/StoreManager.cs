using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour
{
    private Data data = new Data();
    private DataPass datapass = null;
    private StoreContainer storeContainer;
    private DetectorHome detectorHome;
    private Equipation equipation;
    private bool wantLoad = true;


    //[Header("Setting")]//---> aqui es la sección de poner las cosas correctas


    void Start()
    {
        datapass =  FindObjectOfType<DataPass>();
        storeContainer = FindObjectOfType<StoreContainer>();
        detectorHome = FindObjectOfType<DetectorHome>();
        equipation = FindObjectOfType<Equipation>();
    }

    void Update()
    {
        if (!!datapass && !!equipation && !!storeContainer && wantLoad)
        {
            wantLoad = false;
            LoadArea();
            LoadStore();
        }

        if (detectorHome.wantGoHome)
        {
            ReturnHome();
        }
    }



    private void LoadArea()
    {
        ///la idea es que dependiendo del nombre cargue esa dependiendo del orden en data
        ///


        for (int i = 0; i < data.storeTypes.Length; i++)
        {
            for (int x = 0; x < equipation.areas[i].Length; x++)
            {
                TypeOfLoad(data.storeTypes[i], equipation.areas[i][x], x);
            }
            //Debug.Log("De " + data.storeTypes[i] + "  Se cargaron: "+ equipation.areas[i].Length);
        }
    }


    /// <summary>
    /// Cargas uno a uno los hijos del tipo
    /// </summary>
    /// <param name="type"></param>
    /// <param name="childsOfType"></param>
    private GameObject TypeOfLoad(string type, GameObject childOfType, int extraIndex)
    {

        switch (type)
        {
            case "shapes":

                Image img_child = childOfType.GetComponent<Image>();

                if (extraIndex == 0) // token
                {
                    img_child.sprite = datapass.spriteToken;
                }
                else // container
                {
                    img_child.sprite = datapass.spriteContainer;
                }

                break;
            case "powers":

                Animator animator = childOfType.GetComponent<Animator>();
                animator.runtimeAnimatorController = datapass.controllerPower;
                break;
            case "palletes":

                Image img_pal = childOfType.GetComponent<Image>();
               
                img_pal.color = data.palletes[ datapass.indexPalletes[extraIndex]];

                break;
            default:
                Debug.LogError("Typo desconocido....");
                break;
        }
        //datapass.spriteToken
        //    spriteContainer
        //    spritePower
        return childOfType;
    }




    /// <summary>
    /// Cargas los datos a mostrar en la store
    /// </summary>
    private void LoadStore()
    {
        storeContainer.CreatePrefabs_Shapes(datapass.shapesStore);
        storeContainer.CreatePrefabs_Powers(datapass.powersStore);
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
                //Debug.Log(
                //    "Ultimo valor de store: " + last_storeValue +
                //    " | Ultimo valor equipado: " + last_equipedValue +
                //    " | Posición extraida del store: " + storeIndex +
                //    " | Posición extraida del equipado: " + equipedOfType); //--- ignorar esta para power....

                datapass.indexPower = last_storeValue;
                datapass.powersStore[storeIndex] = last_equipedValue;

                break;
            case "palletes":

                datapass.indexPalletes[equipedOfType] = last_storeValue;
                datapass.palleteStore[storeIndex] = last_equipedValue;

                break;
            default:
                Debug.LogError("Type incorrecto");
                break;
        }


    }


    /// <summary>
    /// Tomas el valor de la posicion de la store guardada de tu datapass
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
        datapass.LoadData();
        datapass.LoadResources();
        Debug.Log("A casa");
        SceneManager.LoadScene(0);// te lleva al menú
    }

}