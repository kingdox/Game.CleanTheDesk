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


    [Header("GameManager info")]
    public bool wantInit = true;
    public int score = 0;
    public Text scoreText;

    [Header("Capacity Section")]
    private int capacity_limit = 20; //dejar las privadas aqui para saber ubicarlas

    [Header("Container Section")]


    [Header("Power Section")]
    public int power_count = 0;
    private int power_need = 10;



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


    /// <summary>
    /// CAPACITY
    /// </summary>
    private void CapacityUpdate()
    {

        //Si se acaba la partida
        if (capacity.isGameOver)
        {
            Debug.Log("Game Over");

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