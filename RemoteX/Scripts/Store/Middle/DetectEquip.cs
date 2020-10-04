using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectEquip : MonoBehaviour
{
    private Equipation equipation;

    [Header("El nombre tiene que ser igual al del objeto a detectar")]
    public string nameToDetect = "shapes"; // buscaremos si el objeto posee ese nombre, entonces aplica

    private void Awake()
    {
        equipation = FindObjectOfType<Equipation>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {
        if (token.name == nameToDetect)
        {
            equipation.ChangeEquip(gameObject, token);
        }
    }
}