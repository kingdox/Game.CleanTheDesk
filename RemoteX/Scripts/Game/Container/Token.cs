using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{

    [Header("Container Settings")]
    public Vector3 posToGo;
    private float speed = 10.0f;

    [Header("Token Info")]
    [Space]
    public bool isDraggin;
    public bool isNew = false;


    //startPos = transform.position;

    /*
     * POSEE:
     * -Shape del token
     * - color aleatoria de la paleta
     
     */

    //Este script hace que:
    /*
        -El objeto puede ser agarrado por el mouse
        -El objeto si no es agarrado se mueve a la direccion establecida;
        -Destruye el objeto si este se encuentra agarrado  por el mouse y colisiona con
        el "Contenedor"
     */

    void Update()
    {
        if (isDraggin)
        {
            MouseMovement();
        }
        else
        {
            ReturnMovement();
        }
    }


    private void MouseMovement()
    {
        //TODO entender esto y por qué funciona...
        Vector2 mousePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }


    private void ReturnMovement()
    {
        //TODO entender esto y por qué funciona...
        if (transform.position != posToGo)
        {
            transform.position = Vector3.MoveTowards(
              transform.position, posToGo, Time.deltaTime * speed);
        }
    }

    private void OnMouseDown()
    {
        isDraggin = true;
    }
    private void OnMouseUp()
    {
        isDraggin = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
        //if (collision.CompareTag("Trash") && isDraggin)
        //{
        //    //collision.GetComponent<Container>().ChangeType)
        //    //Destroy(gameObject);
        //}
    }
}