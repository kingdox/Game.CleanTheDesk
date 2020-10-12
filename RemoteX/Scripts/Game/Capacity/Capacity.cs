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


    //TODO usar
    /// <summary>
    /// Este es el que hace comunicación con game manager
    /// </summary>
    /// <param name="cols"></param>
    public void CheckColors( Color[] cols)
    {
        //TODO aqui ponemos el color uno por uno

        for (int x = 0; x < cols.Length; x++)
        {
            capacityBar.SetColor(cols[x], x);
        }
            
    }

}