using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private string initialName; 
    [Header("Field info")]

    public GameObject[] childObjects;
    public bool hasContainer = false; // por defecto falso, se actualiza cada check

    private void Start()
    {
        initialName = name;
    }

    //private void Update()
    //{

    //    //Si hay container, checkeara constantemente si este está presente, sino desactiva..
    //    if (hasContainer)
    //    {
    //        hasContainer = transform.childCount == 0;
    //    }

    //    name = initialName + " [" + transform.childCount + "]";

    //}



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!hasContainer)
    //    {
    //        //añade todos los objetos que encuentra
    //        GameObject obj = collision.gameObject;
    //        obj.transform.SetParent(transform); //gameobj.transform
    //        bool containerExist = obj.CompareTag("Container");
    //        CheckTokens(containerExist);
    //    }
    //}



    ///// <summary>
    ///// Revisa los tokens y los añade a un arreglo
    ///// </summary>
    //private void CheckTokens(bool containerExist) {

    //    int count = transform.childCount; // Sabemos los childs
    //    GameObject[] childs = new GameObject[count];

    //    //si no hay container pone los tokens, si hay elimina los tokens existentes 
    //    if (containerExist)
    //    {
    //        childs = new GameObject[1];

    //        for (int i = 0; i < count; i++)
    //        {
    //            GameObject obj = transform.GetChild(i).gameObject;
    //            if (!obj.CompareTag("Container"))
    //            {
    //                Destroy(obj);
    //            }
    //            else
    //            {
    //                childs = new GameObject[1];
    //                childs[0] = obj;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        for (int x = 0; x < count; x++)
    //        {
    //            childs[x] = transform.GetChild(x).gameObject;
    //        }
    //    }

    //    //Cuando toma todos los objetos los envia directamente al childObj
    //    childObjects = childs;
    //    hasContainer = containerExist;

    //}



    //TODO
    //TODO descomentar lo de arriba, es lo NEW TODO
    //TODO




    //________________




    //    public GameObject groupField;
    //    public int lastType;//FIXME


    //    ///______GT a Field
    //    public int count = 0;
    //    private GameObject[] groupTokens;

    //    private void Update()
    //    {
    //        count = gameObject.transform.childCount;
    //        gameObject.name = "F: (" + count + ")";

    //        if (count == 0)
    //        {
    //            lastType = -1;
    //        }
    //        else
    //        {

    //        }

    //    }


    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (collision.CompareTag("Token"))
    //        {

    //            ////sabemos el token
    //            Token token = collision.gameObject.GetComponent<Token>();

    //            ////Deja de ser nueva la ficha
    //            //token.isNew = false;

    //            ////si esta siendo agarrado o este no pertenece al groupfield
    //            if (!token.transform.IsChildOf(gameObject.transform) && !token.isDraggin)
    //            {
    //                //    //Lo coloca en un grupo
    //                token.transform.SetParent(gameObject.transform);
    //                //    //token.transform.SetParent(groupField.transform);



    //                //    //FIXME esto no es seguro?, revisar Colocamos el tipo de color
    //                //    //lastType = token.GetComponent<ColorController>().colorType;
    //                //    //lastType = groupField.GetComponent<GroupField>().lastT;
    //                //    //Debug.Log("Color ingresado " + lastType);


    //                //    //groupField.name = "G-(" + groupField.transform.childCount + ")";
    //            }
    //        }
    //    }
    //    /// <summary>
    //    /// -Cuando sale algo se saca la ficha
    //    /// -Se cuenta si esta vacío el groupField
    //    /// </summary>
    //    /// <param name="collision"></param>
    //    private void OnTriggerExit2D(Collider2D collision)
    //    {
    //        //collision.gameObject.transform.SetParent(groupField.transform.parent.transform);

    //        //TODO Mover esta condicional ya que no esta bn
    //        //if (count == 0)
    //        //{
    //        //    lastType = -1;
    //        //}
    //        //else
    //        //{

    //        //}
    //    }


    //}

    ///*

    // using System.Collections;
    //using System.Collections.Generic;
    //using UnityEngine;

    //public class Field : MonoBehaviour
    //{

    //    [Header("Settings")]
    //    public GameObject groupField;
    //    public int lastType;

    //    private void Start()
    //    {
    //        lastType = -1;
    //    }

    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (collision.CompareTag("Token"))
    //        {
    //            //sabemos el token
    //            GameObject token = collision.gameObject;

    //            //Colocamos el tipo de color
    //            lastType = token.GetComponent<ColorController>().colorType;

    //            //Deja de ser nueva la ficha
    //            token.GetComponent<Token>().isNew = false; 

    //            //si esta siendo agarrado o este no pertenece al groupfield
    //            if (!token.transform.IsChildOf(groupField.transform) && !token.GetComponent<Token>().isDraggin)
    //            {
    //                token.transform.SetParent(groupField.transform);

    //                groupField.name = "G-(" + groupField.transform.childCount + ")";
    //            }
    //        }

    //    }
    //    private void OnTriggerExit2D(Collider2D collision)
    //    {
    //        //Cuando sale algo se saca la ficha y se cuenta si esta vacío
    //        collision.gameObject.transform.SetParent.transform.se

    //        if (groupField.transform.childCount == 0)
    //        {
    //            lastType = -1;
    //        }
    //    }
}