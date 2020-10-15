using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{

    [Header("Container Settings")]
    public int productionNumber = -1;
    public Vector3 posToGo;
    public float speed = 10.0f;

    [Header("Token Info")]
    [Space]
    public bool isDraggin;
    public bool isNew = true;

    private void Awake()
    {
        isNew = true;
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
        else
        {
            isNew = false;
        }
    }

    private void OnMouseDown()
    {
        isDraggin = !isNew;
    }
    private void OnMouseUp()
    {
        isDraggin = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Detector") && isDraggin)
        {
            GameDetector detector = collision.GetComponent<GameDetector>();
            Token this_token = GetComponent<Token>();
            detector.CheckToken(this_token);
            Destroy(gameObject);
        }
    }
}
