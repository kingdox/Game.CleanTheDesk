using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float intensity = 45.0f; //

    void Update()
    {
        Rotate2D();
    }
    /// <summary>
    /// Rota el objeto en un plano 2D
    /// </summary>
    private void Rotate2D()
    {
        gameObject.transform.Rotate(0.0f, 0.0f, intensity * Time.deltaTime);
    }
}
