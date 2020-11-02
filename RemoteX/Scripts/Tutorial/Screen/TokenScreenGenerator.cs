using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenScreenGenerator : MonoBehaviour
{
    private int screen_w;
    private int screen_h;
    private TokenScreenGenerator tokenScreenGenerator;



    public GameObject tokenSpace;
    public GameObject token_prefab; //este token es el que será generado...



    private float countTime = 0;
    public float spawnCooldown = 1;//0.6f;


    /*
     TODO

        este script hará que se reproduzcan tokens alrededor de la pantalla
        estas se generarán cada cierto tiempo de manera aleatoria en alguna de los extremos
        los extremos pueden ser x, -x , y -y

        tambien hay que ver cuando una sale de la pantalla para que esta sea eliminada
        

     */

    private void Awake()
    {
        screen_w = Screen.width;
        screen_h = Screen.height;
        Debug.Log(screen_h + " | "+ screen_w);
        tokenScreenGenerator = GetComponent<TokenScreenGenerator>();

    }

    void Start()
    {

    }

    private void FixedUpdate()
    {

        if (Time.time > countTime)
        {
            countTime = spawnCooldown + countTime;

            GenerateToken();
        }
    }



    private void GenerateToken()
    {
        //Debug.Log("Generate -->"+ transform.position);
        // 92160 - -150784 - -6400  - -92160 - 150784


        GameObject newToken = Instantiate(token_prefab, tokenSpace.transform);
        TokenTutorial newToken_tkTutorial = newToken.GetComponent<TokenTutorial>();

        
        newToken.transform.localPosition= new Vector3(0, 0, 0);

        // generamos la posicion inicial
        Vector3 pos = GetRandomScreenPosition();
        Debug.Log(pos);
        // generamos la posición a la que se dirige
        Vector3 posToGo = GetRandomScreenPosition();

        newToken.transform.position = pos;

        newToken_tkTutorial.posToGo = posToGo;//new Vector3(posToGo.x, posToGo.y, posToGo.z);

        /*
         
         Vector2 mousePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);

                    transform.position = Vector3.MoveTowards(
              transform.position, posToGo, Time.deltaTime * speed);
         */

    }



    /// <summary>
    /// 
    /// Aquí se genera una posición aleatoria entre algunos de los lados de la pantalla
    /// al inicio se decide hacia que lado irá, random 1-4 para saber donde ponerlo
    /// 
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomScreenPosition()
    {

        //primero vemos a qué eje apuntarás si al X o al Y

        int selectedAxis = Random.Range(0, 3);

        Vector3 pos = new Vector3(0,0,40);

        int randomPos_Y = Random.Range(0, screen_h);
        int randomPos_X = Random.Range(0, screen_w);

        // --> 1 == X
        switch (selectedAxis)
        {
            case 0: // X
                pos = new Vector3(screen_w, randomPos_Y, pos.z);
                break;
            case 1: // -X
                pos = new Vector3(0, randomPos_Y, pos.z);
                break;
            case 2: // Y
                pos = new Vector3(randomPos_X, screen_h, pos.z);
                break;
            case 3: // -Y
                pos = new Vector3(randomPos_X, 0, pos.z);
                break;
        }
        return pos;
    }


}