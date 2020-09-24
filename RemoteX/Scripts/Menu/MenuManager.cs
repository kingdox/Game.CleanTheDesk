using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    /*

        TODO
        Aqui es donde se administrara el menu, para ello hará la gestión de
        Datapass. Cuando GameManager Sepa que los datos fueron Cargados/Creados
        Tendremos un Status ("none/load/save") con el que sabremos como está...
     */


    public DataPass datapass;


    private void Start()
    {

        datapass =  FindObjectOfType<DataPass>() ;// localizamos el data

        //Cuando encuentre dataPass....
        /*
            Coloca a los objetos las imagenes correspondientes
         */


    }

    private void Update()
    {


        if (true)
        {
            //

        }

    }


}
