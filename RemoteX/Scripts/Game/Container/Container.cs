using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    private GameDetector gameDetector;

    [Header("Container info")]
    public GameObject token_prefab;

    [Header("Container->GameManager Comunication")]
    public Color[] token_col; // TODO

    /* 
    * - [HACK] Consigo los fields 
    * - [HACK] Pregunto por sus posiciones en el mundo espacial, y de ello creo un arreglo
    * - [HACK] Este arreglo se lo entrego al Detector
    * - [HACK] El detector basado en lo entregado podrá empezar a generar fichas
    * ACCIONES:
    * TODO--> Envia a GameManager un arreglo con el arreglo de los colores de los tokens ORDENADOS por el Nª de produccion
    */

    private void Awake()
    {
        gameDetector = FindObjectOfType<GameDetector>();

    }



    private void Update()
    {

        //Buscar todos los tokens y ordenarlos, y tomar su color, haciendo un arreglo de colores


    }




    public void InitContainer()
    {
        Transform[] rowss = new Transform[3];
        Field[] fields = new Field[9];
        int fieldCount = 0;
        for (int k = 0; k < 3; k++)
        {
            rowss[k] = transform.GetChild(k);
            for (int i = 0; i < 3; i++)
            {
                fields[fieldCount] = rowss[k].GetChild(i).gameObject.GetComponent<Field>();
                fields[fieldCount].name = "F" + fieldCount;
                fieldCount++;
            }
        }

        gameDetector.fields = fields;
        gameDetector.token_prefab = token_prefab;
    }

    public void SetGameDetector(Sprite container_spr, Sprite token_spr, Color[] palletes_col)
    {
        Image gd_img = gameDetector.GetComponent<Image>();
        gd_img.sprite = container_spr;
        gameDetector.token_spr = token_spr;
        gameDetector.palletes_col = palletes_col;
        StartGameDetector();
    }

    public void StartGameDetector() // uso unico
    {
        
        gameDetector.InitGameDetector();
    }
}






/*
 HACK pero te vienen sin orden :(

 //fields = FindObjectsOfType<Field>();
        //for (int i = 0; i < fields.Length; i++)
        //{
        //    fields[i].name = "F" + i;
        //}
 
 */
