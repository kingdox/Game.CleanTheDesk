using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipation : MonoBehaviour
{

    [Header("Equipment")]

    private GameObject[] areas;

    private void Awake()
    {
        areas = new GameObject[transform.childCount];// contamos la cantidad de objetos.
    }

    void Start()
    {
        
    }



    //TODO
    public void SetRotation(GameObject area, bool condition = true)
    {
        Debug.Log("TEST");
        if (area != null)
        {
            for (int x = 0; x < area.transform.childCount; x++)
            {

                //Activa o desactiva el area correspondiente
                //equipmentArea.transform.GetChild(x)
                //    .gameObject.GetComponent<Rotation>()
                //    .enabled = condition
                //;
            }
        }

    }

}
