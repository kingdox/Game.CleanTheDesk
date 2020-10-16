using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;


public class GameDetector : MonoBehaviour
{
    private Data data = new Data();
    private GameManager gameManager;
    private int tokensCreateds = 0;
    private float countTime = 0;


    [Header("Container Settings")]
    public Sprite token_spr;
    public Color[] palletes_col;
    public Field[] fields;

    [Header("Game Detector info")]
    public GameObject token_prefab;
    public GameObject space;
    public float spawnCooldown = 1.2f;
    public bool init = false;
    public int punishCount = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {


        if (init)
        {

            if (Time.time > countTime)
            {
                countTime = Time.time + spawnCooldown;
                CreateToken();
            }
        }
    }


    public void InitGameDetector()
    {
        //nos ponemos un color cualquiera al inicio de momento
        GetComponent<Image>().color = GetRandomColor();
        CreateToken();
        init = true;
    }

    private void CreateToken()
    {
        GameObject g = Instantiate(token_prefab, space.transform);
        SetToken(g);
        SetTokenImage(g);
    }

    private void SetToken(GameObject g)
    {
        Vector2 pos = GetRandomPosition();

        Token g_tok = g.GetComponent<Token>();
        g_tok.posToGo = new Vector3(pos.x, pos.y, 45);
        g_tok.productionNumber = tokensCreateds; tokensCreateds++; g_tok.name = "T" + g_tok.productionNumber;
        g_tok.speed = 10.0f;
    }
    private void SetTokenImage(GameObject g)
    {
        Image g_img = g.GetComponent<Image>();
        g_img.sprite = token_spr;

        g_img.color = GetRandomColor();//KnowMostColorOnTop();

    }
    private Color GetRandomColor()
    {
        int col = palletes_col.Length;
        return palletes_col[Random.Range(0, col - 1)];
    }
    private Vector2 GetRandomPosition()
    {
        int i = 4;
        while (i == 4) //-- 4 == pos del gameDetector...
        {
            i = Random.Range(0, fields.Length);
        }
        float X = fields[i].transform.position.x;
        float Y = fields[i].transform.position.y;
        Vector2 pos2D = new Vector2(X, Y);
        return pos2D;
    }




    public void CheckToken(Token token)
    {
        Image t_img = token.GetComponent<Image>();
        Image g_img = transform.GetComponent<Image>();


        bool isCorrect = t_img.color == g_img.color;

        if (isCorrect)
        {
            //La ficha introducida es correcta
            SetDetectorColor();

        }
        else
        {
            punishCount++;
            for (int i = 0; i < punishCount; i++)
            {

                CreateToken();  
            }
        }

        gameManager.ContainerResult(t_img.color, isCorrect);

    }




    private void SetDetectorColor()
    {
        Image g_img = transform.GetComponent<Image>();
        //Ponemos un color si es correcto
        int random = Random.Range(0, palletes_col.Length);
        g_img.color = palletes_col[random];
    }




    private Color KnowMostColorOnTop()
    {
        int[] colorCount = new int[palletes_col.Length];
        int most_color = 0;


        for (int x = 0; x < fields.Length; x++)
        {
            if (fields[x].tokenChilds.Length > 0)
            {
                Image t_img = fields[x].tokenChilds[0].GetComponent<Image>();

                for (int i = 0; i < palletes_col.Length; i++)
                {
                    if (t_img.color == palletes_col[i])
                    {
                        colorCount[i]++;

                        if (most_color < colorCount[i])
                        {
                            most_color = colorCount[i];
                        }
                    }

                }
            }
        }


        // como sabemos cual tiene el mayor color,
        // sabemos cuales son posibles para permanecer
        int index = -1;

        while (most_color != 0 || index == -1 || colorCount[index] != most_color)
        {

            index = Random.Range(0, colorCount.Length);

        }

        //retornará el color que mas hay
        //TODO
        return
            most_color != 0
            ? palletes_col[index]
            : GetRandomColor();

    }
}