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
    public GameObject token_prefab;
    public Vector2[] wantedPositions;

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

        KnowWantedPositions();
    }



    private void KnowWantedPositions()
    {
        Debug.Log(fields[0].transform.position);

        float pos_X = fields[5].transform.position.x;
        float pos_Y = fields[5].transform.position.y;

        GameObject g = Instantiate(token_prefab, space.transform);

        //g.transform.localPosition = new Vector3(pos_X,pos_Y,0);
        g.GetComponent<Token>().posToGo = new Vector3(pos_X, pos_Y, 40);

    }

    //TEST
    //IEnumerator StartGame(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    // do something
    //    KnowWantedPositions();
    //}
}

/*
 TODO

    - recibiremos el sprite, el shape nuestro
    y las posiciones esperadas
 
 
 */