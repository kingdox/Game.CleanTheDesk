using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MenuManager : MonoBehaviour
{
    private Data data = new Data();

    /*
        TODO
        Menu Manager se encarga de poner las fichas correspondientes a cada uno
     */


    private DataPass datapass = null;
    private Detector detector; // buscarlo
    private bool wantLoad = true;


    [Header("Cosas")]
    public GameObject loadScreen;
    public Text versionText;

    private void Awake()
    {
        versionText.text = data.version;
    }

    private void Start()
    {

        datapass =  FindObjectOfType<DataPass>();
        detector = FindObjectOfType<Detector>();


    }

    private void Update()
    {


        if (!!datapass && wantLoad)//si ya hay datapass...
        {
            wantLoad = false;
            //Podremos cargar en los lugares correspondientes al inicio...
            SetResources();

            loadScreen.SetActive(false);
        }

    }




    /// <summary>
    /// Aqui cargaras los recursos basado en lo que tiene datapass
    /// </summary>
    public void SetResources()
    {
        Image detImg = detector.gameObject.GetComponent<Image>();
        detImg.sprite = datapass.spriteContainer;

    }



}
