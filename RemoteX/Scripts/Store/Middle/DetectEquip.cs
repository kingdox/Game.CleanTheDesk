using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEquip : MonoBehaviour
{
    private Equipation equipation;

    private string nameToDetect; // buscamos si posee el nombre del parent

    private void Awake()
    {
        equipation = FindObjectOfType<Equipation>();
        nameToDetect = gameObject.transform.parent.name;
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