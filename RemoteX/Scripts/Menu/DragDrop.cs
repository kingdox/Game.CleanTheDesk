using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private readonly Data data = new Data();
    private float speed = 10.0f;
    public bool isDraggin;
    public Vector3 posToGo;

    private AudioSource audioS;
    private AudioClip clip_drag;
    private AudioClip clip_drop;


    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        clip_drag = Resources.Load<AudioClip>(data.path_Sfx + data.audios.drag );
        clip_drop = Resources.Load<AudioClip>(data.path_Sfx + data.audios.drop);
    }


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

        audioS.clip = clip_drag;
        audioS.Play();

    }
    private void OnMouseUp()
    {
        isDraggin = false;

        audioS.clip = clip_drop;
        audioS.Play();
    }
}
