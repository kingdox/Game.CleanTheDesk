using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private readonly Data data = new Data();
    private DataPass dataPass = null;
    private DetectorHome detectorHome;

    [Header("TutorialManager info")]
    public bool wantInit = true;

    private void Start()
    {
        dataPass = FindObjectOfType<DataPass>();
        detectorHome = FindObjectOfType<DetectorHome>();

    }

    void Update()
    {
        if (!!dataPass && dataPass.status == "end" && wantInit)
        {
            wantInit = false;
        }
        if (detectorHome.wantGoHome)
        {
            ReturnHome();
        }

    }


    private void ReturnHome()
    {
        dataPass.tutorial = false;
        dataPass.SaveData(dataPass);
        dataPass.LoadData();
        SceneManager.LoadScene(1);// te lleva al menú
    }

}
