using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorHome : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {
        if (token.name == "Token Back")
        {
            Debug.Log("De vuelta al menú");
            SceneManager.LoadScene(0);// te lleva al menú
        }

    }
}
