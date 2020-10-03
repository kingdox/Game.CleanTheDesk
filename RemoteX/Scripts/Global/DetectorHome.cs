using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorHome : MonoBehaviour
{

    public bool wantGoHome = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {
        if (token.name == "Token Back" && !wantGoHome)
        {
            wantGoHome = true;
        }

    }
}
