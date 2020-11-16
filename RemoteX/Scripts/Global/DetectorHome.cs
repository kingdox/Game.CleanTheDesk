using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorHome : MonoBehaviour
{

    public bool wantGoHome = false;

    public void WantGoHome()
    {
       wantGoHome = true;
    }
}
