using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private readonly Data data = new Data();
    private DataPass dataPass = null;


    [Header("TutorialManager info")]
    public bool wantInit = true;


    private void Start()
    {
        dataPass = FindObjectOfType<DataPass>();
    }

    void Update()
    {
        if (dataPass.status == "end")
        {
           
        }
    }







}
