using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    //    private float speed = 10.0f;
    //    private string type = "none"; //--Not implemented yet

    //    [Header("Posición orígen")]
    //    [Space]
    //    public bool isDraggin;
    //    public Vector3 posToGo;


    //    //Este script hace que:
    //    /*
    //        -El objeto puede ser agarrado por el mouse
    //        -El objeto si no es agarrado se mueve a la direccion establecida;
    //        -Destruye el objeto si este se encuentra agarrado  por el mouse y colisiona con
    //        el "Contenedor"
    //     */
    //    //startPos = transform.position;

    //    void Update()
    //    {
    //        if (isDraggin)
    //        {
    //            MouseMovement();
    //        }
    //        else
    //        {
    //            ReturnMovement();
    //        }
    //    }

    //    private void MouseMovement()
    //    {
    //        Vector2 mousePosition =
    //                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //        transform.Translate(mousePosition);
    //    }


    //    private void ReturnMovement()
    //    {
    //        if (transform.position != posToGo)
    //        {
    //            transform.position = Vector3.MoveTowards(
    //              transform.position, posToGo, Time.deltaTime * speed);
    //        }
    //    }

    //    private void OnMouseDown()
    //    {
    //        isDraggin = true;
    //    }
    //    private void OnMouseUp()
    //    {
    //        isDraggin = false;
    //    }

    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (collision.CompareTag("Trash") && isDraggin)
    //        {
    //            collision.GetComponent<Container>().ChangeType)
    //            Destroy(gameObject);
    //        }
    //    }


}



