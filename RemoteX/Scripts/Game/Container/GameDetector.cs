using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDetector : MonoBehaviour
{


    [Header("Game Detector info")]
    public Sprite token_spr;
    public Color[] palletes_col;
    public Field[] fields;

    [Header("Settings")]
    public GameObject tokenPrefab;

    [Header("Datos creados aqui")]
    public Vector2[] wantedPositions;


    void Start()
    {
        
    }

    void Update()
    {
        
    }


    /// <summary>
    /// TODO
    /// - Busca las posiciones esperadas por los fields
    /// </summary>
    public void InitGameDetector()
    {

    }

}

/*
 TODO

    - recibiremos el sprite, el shape nuestro
    y las posiciones esperadas
 
 
 */