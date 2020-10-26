using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private readonly Data data = new Data();
    private DataPass dataPass = null;
    private Tutorial tutorial;

    [Header("TutorialManager info")]
    public bool wantInit = true;

    private void Awake()
    {
        tutorial = FindObjectOfType<Tutorial>();
    }

    private void Start()
    {
        dataPass = FindObjectOfType<DataPass>();
    }

    void Update()
    {
        if (dataPass.status == "end" && wantInit)
        {
            wantInit = false;
            CheckTutorialStatus();
        }

    }




    private void CheckTutorialStatus()
    {
        Debug.Log("Iniciamos en : " + dataPass.tutorial);

        //si ya hizo el tutorial
        if (dataPass.tutorial)
        {

        }
        else
        {
            //GoToMenu();
        }

    }



    private void GoToMenu()
    {
        dataPass.tutorial = false;
        dataPass.SaveData(dataPass);
        dataPass.LoadData();
        SceneManager.LoadScene(0);// te lleva al menú
    }

}
