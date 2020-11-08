using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class GameDetector : MonoBehaviour
{
    private readonly Data data = new Data();
    private GameManager gameManager;
    private int tokensCreateds = 0;
    private float countTime = 0;
    private int lastPos = 0;
    private int countInGame = 0;

    [Header("Container Settings")]
    public Sprite token_spr;
    public Color[] palletes_col;
    public Field[] fields;
    public Rotation rotation;

    [Header("Game Detector info")]
    public GameObject token_prefab;
    public GameObject space;
    public float spawnCooldown = 0.7f;
    public bool init = false;
    public int punishCount = 0;
    public Image img;

    [Header("Powers Effects")]
    public bool canCreateToken = true;
    public bool power_shadowOn = false;

    private void Awake()
    {
        power_shadowOn = false;
        canCreateToken = true;
        gameManager = FindObjectOfType<GameManager>();
        img = GetComponent<Image>();
        rotation = GetComponent<Rotation>();

        spawnCooldown = data.container_spawnCooldown;
    }

    private void Update()
    {
        if (init)
        {
            if (Time.time > countTime)
            {
                countTime = SetSpawnCooldown();


                if (canCreateToken) // Power
                {
                    CreateToken();
                }
            }


            if (power_shadowOn)
            {
                img.color = data.defaultColor;
            }

        }
    }


    /// <summary>
    /// Basado en la cantidad de fichas y el limite establece una velocidad
    /// tambien hay cosas como un minimo y un maximop de velocidad...?
    /// </summary>
    /// <returns></returns>
    private float SetSpawnCooldown()
    {
        countInGame = KnowCountTokensInGame();

        float newSpawnCD =  (float) countInGame / gameManager.actualLimit;
        //Debug.Log(newSpawnCD + " | " + countInGame + " | " + gameManager.actualLimit);
        newSpawnCD = Mathf.Clamp(newSpawnCD, data.spawnRangeInit[0], data.spawnRangeInit[1]);
        return Time.time + newSpawnCD;
    }


    private int KnowCountTokensInGame()
    {
        int c = 0;
        foreach (var f in fields)
        {
            c += f.countTokens;
        }

        return c;
    }

    public void InitGameDetector()
    {
        Color randomColor = GetRandomColor();
        GetComponent<Image>().color = randomColor;
        CreateToken();
        init = true;
    }
    private Color GetRandomColor()
    {
        int col = palletes_col.Length;
        return palletes_col[Random.Range(0, col)];
    }

    //DONE
    private void CreateToken()
    {
        GameObject g = Instantiate(token_prefab, space.transform);
        Vector3 pos = g.transform.position;
        Vector3 newPos = new Vector3(pos.x, pos.y, data.tokenPosInit_z);
        g.transform.position = newPos;

        Token g_token = g.GetComponent<Token>();
        SetToken(g_token);
    }
    //DONE
    private void SetToken(Token g_token)
    {
        int i = 4;
        while (i == 4 || lastPos == i) //-- 4 == pos del gameDetector...
        {
            i = Random.Range(0, fields.Length);
        }
        lastPos = i;
        float X = fields[i].transform.position.x;
        float Y = fields[i].transform.position.y;


        g_token.posToGo = new Vector3(X, Y, data.tokenPosInit_z);
        g_token.productionNumber = tokensCreateds; tokensCreateds++;
        g_token.name = "T" + g_token.productionNumber;
        g_token.speed = data.tokenSpeed;
        Sprite imgTest = Resources.Load<Sprite>(data.path_Img + data.pathShapes[Random.Range(0, data.pathShapes.Length)]);
        g_token.img.sprite = imgTest;
             //;token_spr;



        bool existTypeOnTop = ExistThisTypeOnTops();
        if (power_shadowOn)
        {
            img.color = data.defaultColor;
        }
        else
        {
            if (existTypeOnTop)
            {
                g_token.img.color = GetRandomColor();
            }
            else
            {
                g_token.img.color = img.color;
            }
        }
    }
    //DONE
    public void CheckToken(Token token)
    {

        bool isCorrect = token.img.color.Equals(img.color)
            || token.img.color.Equals(data.defaultColor)
            || img.color.Equals(data.defaultColor);



        if (!power_shadowOn)
        {

            if (isCorrect)
            {
                //La ficha introducida es correcta
                img.color = KnowMostColorOnTop();

            }
            else
            {
                punishCount++;
                for (int i = 0; i < punishCount; i++)
                {
                    CreateToken();
                }
            }
        }
        else
        {
            img.color = data.defaultColor;
        }



        gameManager.ContainerResult(token.img.color, isCorrect);

    }
    //DONE
    private bool ExistThisTypeOnTops()
    {
        bool existType = false;
        
        for (int i = 0; i < fields.Length; i++)
        {
            if (
                fields[i].tokenChilds.Length > 0
                && fields[i].tokenChilds[0]
                && fields[i].tokenChilds[0].img.color.Equals(img.color)
            ){
                existType = true;
            }
        }

        return existType;
    }

    private Color KnowMostColorOnTop()
    {
        //colorCount posee el indice de los colores y vemos cual posee mas actualmente
        int[] colorCount = new int[palletes_col.Length];
        //most color nos permite saber la cantidad que mas hubo, de manera que sabemos si hay repetida
        int most_color = 0;

        //aqui se recorre los fields
        for (int x = 0; x < fields.Length; x++)
        {
            //por cada field revisamos si poseen tokens
            if (fields[x].tokenChilds.Length > 0 && fields[x].tokenChilds[0])
            {

                //recorremos la paleta de colores
                for (int i = 0; i < palletes_col.Length; i++)
                {

                    //si el color del top de este field es igual a alguno
                    if (fields[x].tokenChilds[0].img.color.Equals(palletes_col[i]))
                    {
                            //asignamos al contador 1 punto en el indice correspondiente
                            colorCount[i]++;

                        //revisamos si este es el contador mas grande actualmente
                        if (colorCount[i] > most_color)
                        {
                            most_color = colorCount[i];
                        }
                    }

                }
            }
        }

        Color col;

        if (most_color != 0)
        {
            Stack<Color> stack_col = new Stack<Color>();

            for (int k = 0; k < colorCount.Length; k++)
            {
                if (colorCount[k] == most_color)
                {
                    //col = palletes_col[k];
                    stack_col.Push(palletes_col[k]);
                }

            }
            col = GetBetweenMostColors(stack_col);
        }
        else
        {
            col = palletes_col[Random.Range(0, palletes_col.Length)];
        }

        return col;
    }



    private Color GetBetweenMostColors(Stack<Color> stack_c)
    {

        Color[] colors = stack_c.ToArray();
        int random = Random.Range(0, colors.Length);
        //Debug.Log("RANDOM---------" + random+ " | sobre : " + colors.Length);
        return colors[random];
    }



}