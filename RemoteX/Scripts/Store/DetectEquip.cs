using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectEquip : MonoBehaviour
{
    public string nameToDetect = "Token"; // buscaremos si el objeto posee ese nombre, entonces aplica

    /*
     * TODO
     * Tipos:
     * -Color
     * -Poder
     * -Imagen
     */


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {
        Debug.Log("Detection!!");
        if (token.name == nameToDetect)
        {
            Debug.Log("Reemplaza la imagen de este objeto con el entrante");
            ChangeEquip();
        }
    }


    private void ChangeEquip()
    {

    }

    /// Dependiendo del tipo cambia su img, color, o animación....


}