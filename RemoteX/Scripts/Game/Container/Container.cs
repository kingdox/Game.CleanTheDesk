using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{

    private Sprite container_spr;
    private Sprite token_spr;
    private Color[] colors;

    private GameObject[] fields;
    private GameObject[] matrix_tokens; // en el futuro usaremos esto apra saber los tokens ?, nesecitaría actualizarse

    private Stack<GameObject> tokens; //Aquí contendremos todos los tokens existentes... ?

    [Header("Container info")]

    private bool isInit;

    public GameObject[] top_tokens;

    void Start()
    {
        
    }

    void Update()
    {



    }




    /// <summary>
    /// Obtenemos localizados los fields para uso futuro
    /// </summary>
    private void SearchFields()
    {
        int  size = 3; // tamaño del matrix 3 * 3 = 9; 9 fields...

        Transform[] rowss = new Transform[size];

        fields = new GameObject[size * size];

        int fieldCount = 0;

        for (int k = 0; k < size; k++)
        {
            Transform row_trans = transform.GetChild(k);
            rowss[k] = row_trans;

            for (int i = 0; i < size; i++)
            {
                fields[fieldCount] = row_trans.GetChild(i).gameObject;
                fieldCount++;
            }
        }
    }




    private void UpdateTopTokens()
    {

    }

}
