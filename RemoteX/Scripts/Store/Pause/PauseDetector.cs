using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseDetector : MonoBehaviour
{
    private GameManager gameManager;
    public Image img;


    private void Awake()
    {
        img = GetComponent<Image>();
        gameManager = FindObjectOfType<GameManager>();
    }









    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {

        //Debug.Log(token.name);

        string text = token.name;

        switch (text)
        {
            case "Reload":
                SceneManager.LoadScene(1);
                break;

            case "Play":
                //Hace un resume de la partida
                gameManager.SwitchPause(false);
                break;

            default:
                // cualquier otro no importante...
                break;
        }
        DragDrop DaD = token.GetComponent<DragDrop>();
        DaD.isDraggin = false;
        RectTransform rt = token.GetComponent<RectTransform>();
        rt.transform.localPosition = new Vector3(0, 0, 0);

        //Destroy(token);
    }










}
