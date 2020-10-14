using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;


public class GameDetector : MonoBehaviour
{


    [Header("Game Detector info")]
    public Sprite token_spr;
    public Color[] palletes_col;
    public Field[] fields;

    [Header("Container Settings")]
    public GameObject token_prefab;
    public GameObject space;

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
        //En teoria ya tenemos los fields..

        CreateToken();
    }



    private void CreateToken()
    {

        int fIndex = 4;
        while (fIndex == 4) //-- 4 == pos del gameDetector...
        {
            fIndex = Random.Range(0, fields.Length);
        }

        Vector2 pos = KnowWantedPositions(fields[fIndex]);
        GameObject g = Instantiate(token_prefab, space.transform);//transform.parent.transform); //

        Token g_tok = g.GetComponent<Token>();
        g_tok.posToGo = new Vector3(pos.x, pos.y, 40);

        Image g_img = g.GetComponent<Image>();
        g_img.sprite = token_spr;

        int col = palletes_col.Length;
        g_img.color = palletes_col[Random.Range(0, col - 1)];

    }

    private Vector2 KnowWantedPositions(Field f)
    {
        float X = f.transform.position.x;
        float Y = f.transform.position.y;
        Vector2 pos2D = new Vector2(X, Y);
        return pos2D;
    }


}

/*
 TODO

    - recibiremos el sprite, el shape nuestro
    y las posiciones esperadas
 
 
 */