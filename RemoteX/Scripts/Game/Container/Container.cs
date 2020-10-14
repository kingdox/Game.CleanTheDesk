using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{

    private GameDetector gameDetector;
    //private Stack<GameObject> tokens; //Aquí contendremos todos los tokens existentes... ?
    public GameObject token_prefab;
    [Header("Container info")]
    public Field[] fields;
    private bool isInit;

    public GameObject[] top_tokens;

    public bool wantInit= false;

    private void Awake()
    {
        gameDetector = FindObjectOfType<GameDetector>();   
    }

    void Start()
    {
        InitFields();
        /* 
         * TODO
         * - Consigo los fields [HACK]
         * - Pregunto por sus posiciones en el mundo espacial, y de ello creo un arreglo
         * - Este arreglo se lo entrego al Detector
         * - *-El detector basado en lo entregado podrá empezar a generar fichas
         * 
         */
    }

    void Update()
    {



    }


    /// <summary>
    /// Desde gameManager le pasamos la informacion a GameDetector
    /// </summary>
    /// <param name="container_spr"></param>
    /// <param name="token_spr"></param>
    /// <param name="palletes_col"></param>
    public void SetGameDetector(Sprite container_spr, Sprite token_spr, Color[] palletes_col)
    {
        Image gd_img = gameDetector.GetComponent<Image>();
        gd_img.sprite = container_spr;

        gameDetector.token_spr = token_spr;
        gameDetector.palletes_col = palletes_col;

    }

    private void InitFields()
    {
        Transform[] rowss = new Transform[3];
        fields = new Field[9];
        int fieldCount = 0;
        for (int k = 0; k < 3; k++)
        {
            rowss[k] = transform.GetChild(k);
            for (int i = 0; i < 3; i++)
            {
                fields[fieldCount] = rowss[k].GetChild(i).gameObject.GetComponent<Field>();
                fields[fieldCount].name = "F"+fieldCount;
                fieldCount++;
            }
        }
        StartGameDetector();
    }

    public void StartGameDetector()
    {
        gameDetector.fields = fields; //entregamos el fields a gameDetector;
        gameDetector.token_prefab = token_prefab;
        gameDetector.InitGameDetector();
    }
}