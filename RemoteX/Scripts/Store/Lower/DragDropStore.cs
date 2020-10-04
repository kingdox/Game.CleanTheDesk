using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropStore : MonoBehaviour
{
    private float speed = 10.0f;
    public bool isDraggin;
    public Vector3 posToGo;


    void Start()
    {
        posToGo = transform.position;
    }

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
        Vector2 mousePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
    }


    private void ReturnMovement()
    {
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
}
