using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDetector : MonoBehaviour
{
    private GameManager gameManager;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {
        string text = token.name.ToLower();

        switch (text)
        {
            case "home":
            case "Home":
                SceneManager.LoadScene(1);
                break;
            case "reset":
            case "Reset":
                SceneManager.LoadScene(2);
                break;
            case "store":
            case "Store":
                SceneManager.LoadScene(3);
                break;

            default:
                break;

        }

    }
}
