using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    private GameDetector gameDetector;
    private Data data = new Data();

    [Header("Container info")]
    public GameObject token_prefab;
    public Image img;

    [Header("Powers")]
    public bool test;

    private void Awake()
    {
        gameDetector = FindObjectOfType<GameDetector>();
        img = GetComponent<Image>();

    }


    public void InitContainer()
    {
        Transform[] rowss = new Transform[3];
        Field[] fields = new Field[9];
        int fieldCount = 0;
        for (int k = 0; k < 3; k++)
        {
            rowss[k] = transform.GetChild(k);
            for (int i = 0; i < 3; i++)
            {
                fields[fieldCount] = rowss[k].GetChild(i).gameObject.GetComponent<Field>();
                fields[fieldCount].name = "F" + fieldCount;

                fields[fieldCount].hasContainer = fieldCount == 4;
                fieldCount++;
            }
        }

        gameDetector.fields = fields;
        gameDetector.token_prefab = token_prefab;
    }

    public void SetGameDetector(Sprite container_spr, Sprite token_spr, Color[] palletes_col)
    {
        Image gd_img = gameDetector.GetComponent<Image>();
        gd_img.sprite = container_spr;
        gameDetector.token_spr = token_spr;
        gameDetector.palletes_col = palletes_col;
        StartGameDetector();
    }

    public void StartGameDetector() // uso unico
    {
        gameDetector.InitGameDetector();
    }

    public void ShutDownContainer()
    {
        gameDetector.gameObject.SetActive(false);
    }


    //Usado en  Power
    public void CanGameDetectorCreateTokens(bool condition){

        gameDetector.canCreateToken = condition;
        gameDetector.rotation.enabled = condition;

    }



    public void SetPowerShadows(bool condition)
    {
        gameDetector.power_shadowOn = condition;

        if (!condition) 
        {
            img.color = data.defaultColor;
        }
    }

}