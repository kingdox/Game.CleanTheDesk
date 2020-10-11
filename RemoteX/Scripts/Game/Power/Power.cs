using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    private PowerBar powerBar;


    //[Header("From GameManager")]


    [Header("Power Info")]
    public bool isPressed = false;
    public bool isAvailable = false;
    public Animator power_anim;

    private void Awake()
    {
        powerBar = FindObjectOfType<PowerBar>();

    }


    public void WasPressed()
    {
        isPressed = true;
    }

    public void SetAnimation(RuntimeAnimatorController ctrl)
    {
        power_anim.runtimeAnimatorController = ctrl;
        power_anim.Play("Stop");

    }

    public void SetPowerBarLimit(int limit)
    {
        powerBar.limit = limit;

    }


    //    public string power;
    //    public Image iconPower;


    //    public bool canPower = false;
    //    private int powerBar = 0;
    //    private int powerNeed = 20;


    //    //[POWER STUFF]_________

    //    private Container container;


    //    //______________________


    //    private void Awake()
    //    {
    //        container = FindObjectOfType<Container>();

    //    }


    //    public void SetPower(string power = "")
    //    {
    //        if (power == "")
    //        {
    //            Debug.Log("FUncionamiento OK");
    //            canPower = false;
    //        }
    //    }


    //    /// <summary>
    //    /// Se añade a power un punto y se verifica si es suficiente para usarse
    //    /// </summary>
    //    public void PowerAdition()
    //    {
    //        powerBar++;

    //        CanPower();
    //    }



    //    public void PowerActivate()
    //    {
    //        if (!canPower)
    //        {
    //            return;
    //        }

    //        StartCoroutine(PowerCoroutine());

    //        //switch (power)//String con el nombre del power
    //        //{
    //        //    case "time": //detienes la generación de fichas por powerNeed
    //        //        Debug.Log("Time was pressed");
    //        //        //reduzco la generacióna qui y tambien se la devuelvo aqui, suma y resta de float
    //        //        //así si añado a futuro adición de time no habrá bugs raros

    //        //        break;

    //        //    default:
    //        //        Debug.Log("No conocido");
    //        //        break;
    //        //}


    //        powerBar -= powerNeed;
    //        CanPower();
    //    }

    //    IEnumerator PowerCoroutine()
    //    {
    //        Debug.Log("Poder: " + power);


    //        switch (power)
    //        {
    //            case "time":
    //                // reduces la velocidad
    //                //container.sp
    //                float pastContainerCD = container.spawnCoolDown;
    //                container.spawnCoolDown
    //                yield return new WaitForSeconds(powerNeed / 3);

    //                // aumentas la velocidad

    //                break;

    //            default:
    //                break;
    //        }

    //        //yield return new WaitForSeconds();
    //        Debug.Log("200000");

    //    }

    //    private void CanPower()
    //    {
    //        canPower = powerBar >= powerNeed;

    //        iconPower.gameObject.SetActive(canPower);
    //  /*
    //   using System.Collections;
    //using System.Collections.Generic;
    //using UnityEngine;
    //using UnityEngine.UI;

    //public class Power : MonoBehaviour
    //{
    //    public string power;
    //    public Image iconPower;


    //    public bool canPower = false;
    //    private int powerBar = 0;
    //    private int powerNeed = 20;


    //    //[POWER STUFF]_________

    //    private Container container;


    //    //______________________


    //    private void Awake()
    //    {
    //        container = FindObjectOfType<Container>();

    //    }


    //    public void SetPower(string power = "")
    //    {
    //        if (power == "")
    //        {
    //            Debug.Log("FUncionamiento OK");
    //            canPower = false;
    //        }
    //    }


    //    /// <summary>
    //    /// Se añade a power un punto y se verifica si es suficiente para usarse
    //    /// </summary>
    //    public void PowerAdition()
    //    {
    //        powerBar++;

    //        CanPower();
    //    }



    //    public void PowerActivate()
    //    {
    //        if (!canPower)
    //        {
    //            return;
    //        }

    //        StartCoroutine(PowerCoroutine());

    //        //switch (power)//String con el nombre del power
    //        //{
    //        //    case "time": //detienes la generación de fichas por powerNeed
    //        //        Debug.Log("Time was pressed");
    //        //        //reduzco la generacióna qui y tambien se la devuelvo aqui, suma y resta de float
    //        //        //así si añado a futuro adición de time no habrá bugs raros

    //        //        break;

    //        //    default:
    //        //        Debug.Log("No conocido");
    //        //        break;
    //        //}


    //        powerBar -= powerNeed;
    //        CanPower();
    //    }

    //    IEnumerator PowerCoroutine()
    //    {
    //        Debug.Log("Poder: " + power);


    //        switch (power)
    //        {
    //            case "time":
    //                // reduces la velocidad
    //                //container.sp
    //                float pastContainerCD = container.spawnCoolDown;
    //                container.spa
    //                yield return new WaitForSeconds(powerNeed / 3);

    //                // aumentas la velocidad

    //                break;

    //            default:
    //                break;
    //        }

    //        //yield return new WaitForSeconds();
    //        Debug.Log("200000");

    //    }

    //    private void CanPower()
    //    {
    //        canPower = powerBar >= powerNeed;

    //        iconPower.gameObject.SetActive(canPower);
    //    }
    //}

    //   */
    ///*
    // using System.Collections;
    //using System.Collections.Generic;
    //using UnityEngine;
    //using UnityEngine.UI;

    //public class Power : MonoBehaviour
    //{
    //  public string power;
    //  public Image iconPower;


    //  public bool canPower = false;
    //  private int powerBar = 0;
    //  private int powerNeed = 20;


    //  //[POWER STUFF]_________

    //  private Container container;


    //  //______________________


    //  private void Awake()
    //  {
    //      container = FindObjectOfType<Container>();

    //  }


    //  public void SetPower(string power = "")
    //  {
    //      if (power == "")
    //      {
    //          Debug.Log("FUncionamiento OK");
    //          canPower = false;
    //      }
    //  }


    //  /// <summary>
    //  /// Se añade a power un punto y se verifica si es suficiente para usarse
    //  /// </summary>
    //  public void PowerAdition()
    //  {
    //      powerBar++;

    //      CanPower();
    //  }



    //  public void PowerActivate()
    //  {
    //      if (!canPower)
    //      {
    //          return;
    //      }

    //      StartCoroutine(PowerCoroutine());

    //      //switch (power)//String con el nombre del power
    //      //{
    //      //    case "time": //detienes la generación de fichas por powerNeed
    //      //        Debug.Log("Time was pressed");
    //      //        //reduzco la generacióna qui y tambien se la devuelvo aqui, suma y resta de float
    //      //        //así si añado a futuro adición de time no habrá bugs raros

    //      //        break;

    //      //    default:
    //      //        Debug.Log("No conocido");
    //      //        break;
    //      //}


    //      powerBar -= powerNeed;
    //      CanPower();
    //  }

    //  IEnumerator PowerCoroutine()
    //  {
    //      Debug.Log("Poder: " + power);


    //      switch (power)
    //      {
    //          case "time":
    //              // reduces la velocidad
    //              //container.sp
    //              float past
    //              yield return new WaitForSeconds(powerNeed / 3);

    //              // aumentas la velocidad

    //              break;

    //          default:
    //              break;
    //      }

    //      //yield return new WaitForSeconds();
    //      Debug.Log("200000");

    //  }

    //  private void CanPower()
    //  {
    //      canPower = powerBar >= powerNeed;

    //      iconPower.gameObject.SetActive(canPower);
    //  }
    //}

    // */

    ///*


    // using System.Collections;
    //using System.Collections.Generic;
    //using UnityEngine;
    //using UnityEngine.UI;

    //public class Power : MonoBehaviour
    //{
    //public string power;
    //public Image iconPower;


    //public bool canPower = false;
    //private int powerBar = 0;
    //private int powerNeed = 20;


    ////[POWER STUFF]_________

    //private Container container;


    ////______________________


    //private void Awake()
    //{
    //container = FindObjectOfType<Container>();

    //}


    //public void SetPower(string power = "")
    //{
    //if (power == "")
    //{
    //    Debug.Log("FUncionamiento OK");
    //    canPower = false;
    //}
    //}


    ///// <summary>
    ///// Se añade a power un punto y se verifica si es suficiente para usarse
    ///// </summary>
    //public void PowerAdition()
    //{
    //powerBar++;

    //CanPower();
    //}



    //public void PowerActivate()
    //{
    //if (!canPower)
    //{
    //    return;
    //}

    //StartCoroutine(PowerCoroutine());

    ////switch (power)//String con el nombre del power
    ////{
    ////    case "time": //detienes la generación de fichas por powerNeed
    ////        Debug.Log("Time was pressed");
    ////        //reduzco la generacióna qui y tambien se la devuelvo aqui, suma y resta de float
    ////        //así si añado a futuro adición de time no habrá bugs raros

    ////        break;

    ////    default:
    ////        Debug.Log("No conocido");
    ////        break;
    ////}


    //powerBar -= powerNeed;
    //CanPower();
    //}

    //IEnumerator PowerCoroutine()
    //{
    //Debug.Log("Poder: " + power);


    //switch (power)
    //{
    //    case "time":
    //        // reduces la velocidad
    //        //container.sp
    //        float 
    //        yield return new WaitForSeconds(powerNeed / 3);

    //        // aumentas la velocidad

    //        break;

    //    default:
    //        break;
    //}

    ////yield return new WaitForSeconds();
    //Debug.Log("200000");

    //}

    //private void CanPower()
    //{
    //canPower = powerBar >= powerNeed;

    //iconPower.gameObject.SetActive(canPower);
    //}
}

// */
