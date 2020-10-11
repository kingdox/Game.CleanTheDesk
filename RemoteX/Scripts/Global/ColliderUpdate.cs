using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColliderUpdate : MonoBehaviour
{
    //Por ver....
    private CircleCollider2D circleCollider2D;
    private Image image;

    private float last_radius;

    private void Awake()
    {
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        image = gameObject.GetComponent<Image>();

        last_radius = circleCollider2D.radius;
       
    }

    private void Update()
    {
        if (!!image.sprite)
        {
            changeRadius();
        }

    }

    private void changeRadius()
    {

        float w = Screen.width / image.sprite.rect.width;
        float h = Screen.height / image.sprite.rect.height;
        float radiusAprox = w + h + 10;

        if (radiusAprox != last_radius)
        {
            last_radius = radiusAprox;
            circleCollider2D.radius = last_radius;
        }
    }
}

//HACK con esto volvemos responsive el collider, pero dependemos de una imagen