using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacity : MonoBehaviour
{
    public Sprite token_spr;

    public bool isGameOver = false;
    public int limit = 20;


    private void Start()
    {
            
    }


    private void Update()
    {

        CheckGameStatus();

    }



    private void CheckGameStatus()
    {
        if (transform.childCount == limit)
        {
            isGameOver = true;  
        }
    }



    //    public GameObject capacityBlockPrefab;
    //    public GameObject[] capacityBlock;

    //    //Añade, revisar si color = -1 significa que no hay y hay que quitar
    //    public void UpdateCapacity(int color = -1)
    //    {
    //        if (color != -1)
    //        {
    //            Debug.Log("PEEP");

    //            GameObject obj = Instantiate(capacityBlockPrefab, gameObject.transform, Quaternion.identity(ga);

    //            obj.GetComponent<ColorController>().colorType = 2;
    //            obj.GetComponent<ColorController>().SetColor();
    //            return;

    //            //Creo y añado el nuevo bloque
    //            ColorController newBlock = obj.GetComponent<ColorController>();

    //            newBlock.colorType = color;//FIXME color controler o poner con gameObject
    //            newBlock.isBackGround = true;
    //            newBlock.SetColor();
    //        }

    //        //recuento la cantidad de bloques
    //        GameObject[] block = new GameObject[gameObject.transform.childCount];

    //        for (int i = 0; i < block.Length; i++)
    //        {
    //            block[i] = gameObject.transform.GetChild(i).gameObject;
    //        }

    //        foreach (var i in block)
    //        {
    //            //i.GetComponent<ColorController>
    //        }
    //    }
}