using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private DetectorHome detectorHome;

    void Start()
    {
        detectorHome = FindObjectOfType<DetectorHome>();

    }

    void Update()
    {
        if (detectorHome.wantGoHome)
        {
            ReturnHome();
        }
    }



    private void ReturnHome()
    {
        //datapass.SaveData(datapass);
        //datapass.LoadData();
        //datapass.LoadResources();
        //Debug.Log("A casa");
        SceneManager.LoadScene(0);// te lleva al menú
    }
}
