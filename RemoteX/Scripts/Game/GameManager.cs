using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private readonly Data data = new Data();
    private DataPass dataPass = null;
    private Capacity capacity;
    private Container container;
    private Power power;
    private DetectorHome detectorHome;
    private bool isEnd = false;
    private int power_need = 10;


    [Header("GameManager info")]
    public GameObject game;
    public bool wantInit = true;
    public int score = 0;
    public Text scoreText;

    [Header("Container Section")]
    public bool BGisDark = false;

    [Header("Power Section")]
    public int power_count = 0;
    public bool powerDisabled = false;

    [Header("Pause Section")]
    public GameObject pause;
    public Text pauseScoreText;
    public Text pauseHighScoreText;
    public PauseDetector pauseDetector;
    public bool pauseWasInit = true;

    [Header("Transition Section")]
    public GameObject transition;

    [Header("Power Effects")]
    public bool multiplierOn = false;


    private void Awake()
    {
        multiplierOn = false;
    }

    private void Start()
    {
        capacity = FindObjectOfType<Capacity>();
        container = FindObjectOfType<Container>();
        power = FindObjectOfType<Power>();
        dataPass = FindObjectOfType<DataPass>();
        detectorHome = FindObjectOfType<DetectorHome>();
        pauseDetector = FindObjectOfType<PauseDetector>();

        pause.SetActive(false);
        transition.SetActive(false);
        //GameManager Starter
        pauseWasInit = false;
        wantInit = true;
        score = 0;
        scoreText.text = score.ToString();
        powerDisabled = false;
    }


    private void Update()
    {
        scoreText.text = score.ToString();
        pauseScoreText.text = score.ToString();
        pauseHighScoreText.text = "*"+dataPass.highScore.ToString() + "*";



        if (dataPass.status == "end" )
        {
            if (game.activeInHierarchy)
            {
                if (wantInit)
                {
                    //Debug.Log("Init");
                    InitGameManager();
                }
                else
                {
                    ChildUpdates();
                
                }
            }

            if (pause.activeInHierarchy)
            {
                if (!pauseWasInit)
                {
                    pauseWasInit = true;

                    pauseDetector.img.sprite = dataPass.spriteContainer;

                }
                if (detectorHome.wantGoHome)
                {
                    SceneManager.LoadScene(0);
                }

            }
            
        }

        

        
    }


    private void InitGameManager()
    {
        wantInit = false;
        // Init Capacity
        capacity.SetLimit(data.token_limit);

        // Init Container
        container.InitContainer();
        container.SetGameDetector(dataPass.spriteContainer, dataPass.spriteToken, dataPass.palletes);

        // Init Power
        power_count = 0;
        power_need = data.powersRequireds[dataPass.indexPower];
        power.SetPowerBarLimit(power_need);
        power.SetAnimation(dataPass.controllerPower);

    }


   

    public void IsGameOver()
    {
        if (isEnd)
        {
            return;
        }
        isEnd = true;


        Debug.Log("Game Over");
        container.ShutDownContainer();

        // revisar si tenemos highScore

        dataPass.highScore = score > dataPass.highScore ? score : dataPass.highScore;
        dataPass.SaveData(dataPass);

    }



    public void ContainerResult(Color c , bool isSuccesful)
    {
        Image container_img = container.GetComponent<Image>();

        if (isSuccesful)
        {
            score += multiplierOn ? 2 : 1;

            if (!powerDisabled)
            {
                power_count++;
                power.UpdatePowerBarCount(power_count);
            }

            container_img.color = new Color(c.r, c.g, c.b, BGisDark ? 0.7f : 1);
            BGisDark = !BGisDark;
        }
        else
        {
            container_img.color = new Color(1,1,1,1);
        }

    }

    // ##-------UPDATES---

    private void ChildUpdates()
    {
        if (!isEnd)
        {
            //Aqui se pone las cosas cuando ya ha sido cargado...
            CapacityUpdate();
            PowerUpdate();
        }
    }

    private void CapacityUpdate()
    {
        if (capacity.isGameOver)
        {
            IsGameOver();
        }
    }
    private void PowerUpdate()
    {
        // si fue presionado
        if (power.isPressed && !powerDisabled)
        {
            power.isPressed = false;
            if (power_count >= power_need)
            {
                power_count = 0;
                power.UpdatePowerBarCount(power_count);
                ActivePower();
            }
        }
    }

    private void ActivePower()
    {
        Debug.Log("Ha sido presionado y puede usar poder");
        //dependiendo del poder que tiene datapass jugamos algo distinto...
        //TODO activar la animacion del poder por X tiempo, dependiendo de la que sea...
        float delay = data.powerDelays[dataPass.indexPower];
        powerDisabled = true;
        //Basado en PathPowers
        switch (dataPass.indexPower)
        {
            case 0:
                Debug.Log("Time");
                container.CanGameDetectorCreateTokens(false);
                break;

            case 1:
                Debug.Log("Multiplier");
                multiplierOn = true;
                break;

            case 2:
                Debug.Log("Plus");
                capacity.SetLimit(capacity.limit + 1);
                power_need++;
                power.SetPowerBarLimit(power_need);
                break;

            case 3:
                Debug.Log("...--");
                break;

            case 4:
                Debug.Log("...");
                break;

            default:
                Debug.LogError("Poder Desconocido");

                break;
        }
        StartCoroutine(PowerWait(delay));


    }


    /// <summary>
    /// Hecho para efectos que requieren tiempo de espera
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    private IEnumerator PowerWait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        powerDisabled = false;

        //Basado en PathPowers
        switch (dataPass.indexPower)
        {
            case 0:
                Debug.Log("Time");

                container.CanGameDetectorCreateTokens(true);
                break;

            case 1:
                Debug.Log("Multiplier");
                multiplierOn = false;
                break;

            case 2:
                Debug.Log("Plus");
                break;

            case 3:
                Debug.Log("...--");
                break;

            case 4:
                Debug.Log("...");
                break;

            default:
                Debug.LogError("Poder Desconocido");

                break;
        }

    }
}