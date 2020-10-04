using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationStore : MonoBehaviour
{
    private Data data = new Data();
    private StoreContainer storeContainer;
    public GameObject textNav;
    private Text textNavText;

    private void Start()
    {
        storeContainer = FindObjectOfType<StoreContainer>();
        textNavText = textNav.GetComponent<Text>();
        textNavText.text = "0";

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {
        int length = data.storeTypes.Length;
        int index = 0;

        for (int i = 0; i < length; i++)
        {
            if (data.storeTypes[i] == storeContainer.lastStore)
            {
                index = i;
            }
        }


        switch (token.name) 
        {
            case "Left":
                index--;
                break;

            case "Right":
                index++;
                break;

            default:
                //Debug.LogError("Error con el nombre");
                return;
        }

        if (length == index)
        {
            index = 0;
        }else if(index == -1)
        {
            index = length - 1;
        }

        //Debug.Log("Cambiado a: " + data.storeTypes[index]) ;
        textNavText.text = index.ToString() ;
        storeContainer.ChangeTo(data.storeTypes[index]);

    }





}


//si una de estas 2 flechas hace contacto entonces