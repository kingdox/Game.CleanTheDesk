using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private readonly Data data = new Data();
    private DataPass dataPass = null;
    private Capacity capacity;
    private Container container;
    private Power power;
    private bool isEnd = false;
    private int capacity_limit = 20; //dejar las privadas aqui para saber ubicarlas
    private int power_need = 10;


    [Header("GameManager info")]
    public bool wantInit = true;
    public int score = 0;
    public Text scoreText;


    [Header("Power Section")]
    public int power_count = 0;



    private void Start()
    {
        capacity = FindObjectOfType<Capacity>();
        container = FindObjectOfType<Container>();
        power = FindObjectOfType<Power>();
        dataPass = FindObjectOfType<DataPass>();

        //GameManager Starter
        wantInit = true;
        score = 0;
        scoreText.text = score.ToString();
    }


    private void Update()
    {
        scoreText.text = score.ToString();

        if (dataPass.status == "end")
        {
            if (wantInit)
            {
                Debug.Log("Init");
                InitGameManager();
            }
            else
            {
                //Aqui se pone las cosas cuando ya ha sido cargado...
                CapacityUpdate();
                PowerUpdate();
            }
        }
    }


    private void InitGameManager()
    {
        wantInit = false;
        // Init Capacity
        capacity.SetLimit(capacity_limit);

        // Init Container
        container.InitContainer();
        container.SetGameDetector(dataPass.spriteContainer, dataPass.spriteToken, dataPass.palletes);

        // Init Power
        power_count = 0;
        power_need = data.powersRequireds[dataPass.indexPower];
        power.SetPowerBarLimit(power_need);
        power.SetAnimation(dataPass.controllerPower);

    }


   

    public void isGameOver()
    {
        if (isEnd)
        {
            return;
        }
        isEnd = true;


        Debug.Log("Game Over");
        container.ShutDownContainer();

    }



    public void ContainerResult(Color c , bool isSuccesful)
    {
        Image container_img = container.GetComponent<Image>();

        if (isSuccesful)
        {
            score++;
            container_img.color = c;
        }
        else
        {
            container_img.color = new Color(1,1,1,1);
        }

    }

    // ##-------UPDATES---

    private void CapacityUpdate()
    {
        if (capacity.isGameOver)
        {
            isGameOver();
        }
    }




    /// <summary>
    /// POWER
    /// </summary>
    private void PowerUpdate()
    {
        // si fue presionado
        if (power.isPressed)
        {
            power.isPressed = false;
            if (power.isAvailable)
            {
                power.isAvailable = false;
                Debug.Log("Ha sido presionado y puede usar poder");
                ActivePower();
            }
        }
    }

    private void ActivePower()
    {
        //dependiendo del poder que tiene datapass jugamos algo distinto...
    }
}