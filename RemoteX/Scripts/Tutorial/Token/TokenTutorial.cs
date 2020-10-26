using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenTutorial : MonoBehaviour
{
    [Header("TutorialVersion")]

    public float speed = 10.0f;
    public bool isNew = true;


    public Vector3 posToGo = new Vector3(0,0,0);

    /*
    TODO

        Aqui la ficha  tendrá que  ser tomada con una random,
        al ser tocada por el usuario interactuará con Tutorial para emitir el siguiente Step

     */


    private void Awake()
    {
        posToGo = new Vector3(0, 0, 0);

    }


    private void OnMouseDown()
    {
        // Revisamos el estado actual y, en caso de  ejecutamos algo...


    }

    private void Update()
    {

        if (transform.position.Equals(posToGo))
        {
            Destroy(gameObject);    
        }
    }

}
