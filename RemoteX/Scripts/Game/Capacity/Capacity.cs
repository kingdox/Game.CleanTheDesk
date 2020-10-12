using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capacity : MonoBehaviour
{
    private CapacityBar capacityBar;
    private int limit = 20;

    [Header("Capacity info")]
    public bool isGameOver = false;
    public Text capacityText;

    private void Awake()
    {
        capacityBar = FindObjectOfType<CapacityBar>();
    }

    private void Start()
    {


    }


    private void Update()
    {
        capacityText.text = capacityBar.transform.childCount + " / " + limit.ToString();
        CheckGameStatus();

    }


    private void CheckGameStatus()
    {
        if (capacityBar.transform.childCount >= limit)
        {
            isGameOver = true;  
        }
    }


    public void SetLimit(int l)
    {
        limit = l; //-- actualizamos
        capacityBar.ReSize(limit);

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