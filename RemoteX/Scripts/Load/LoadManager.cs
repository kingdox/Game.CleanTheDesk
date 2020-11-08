using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{

    private DataPass datapass;

    private bool wantLoad = true;

    private void Awake()
    {
        wantLoad = true;
    }

    private void Start()
    {
        datapass = FindObjectOfType<DataPass>();
    }

    private void Update()
    {
        if (!!datapass && datapass.status == "end" && wantLoad)
        {
            wantLoad = false;
            NavigateTo();
        }
    }




    /// <summary>
    /// Decide si llevarte al menu o al tutorial
    /// </summary>
    private void NavigateTo()
    {

        Debug.Log($"Tutorial? {datapass.tutorial} ");
        SceneManager.LoadScene( datapass.tutorial
            ? 5
            : 1
        );
    }
     
}
