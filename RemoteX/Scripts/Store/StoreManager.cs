using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
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
        if (!!datapass && wantLoad)//si ya hay datapass...
        {
            wantLoad = false;

            storeContainer.CreatePrefabs_IMG(datapass.lastStore);

        }
    }








}
/*

Aqui se muestra 2 lineas con puros diseños para container y Token
( tambien colores y poderes) ?

(Cuandos los compras se van hacia Area Upper donde puedes equipartelos

*/




/*
 
 Como tecnicamente estas intercambiando poderes o fichas con el mercado

cada vez que inicias el juego, el Datapass contendrá la información que se pondrá
en el mercado, de manera que esta siemrpe va a ser la misma a no ser que
juegues x cantidad de partidas, de manera que no se puede abusar de la tienda
estas cosas se guardarán en ladata guardada
un array con la store actual
 
 
 */