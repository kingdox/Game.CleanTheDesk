using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTokenGen : MonoBehaviour
{
    private readonly Data data = new Data();
    public GameObject selectedArea;

    public GameObject tokenPrefab;

    public string isInPosition = "left"; //left, right,up,down, Y/X? +Y -Y

    public float lastPosition; //basado en el eje,;

    public float minPos;
    public float maxPos;

    //el tamaño es basado al height de algo



    private void Awake()
    {
        //parentArea = gameObject.transform.parent.gameObject;// tenemos el padre
    }
    void Start()
    {
        RectTransform rec = selectedArea.GetComponent<RectTransform>();
        Debug.Log(rec.localPosition + " - " + rec.anchorMax.y + " min " + rec.anchorMin.y); //el segundo es el eje Y
        minPos = rec.anchorMin.y;
        maxPos = rec.anchorMax.y;
    }

    void Update()
    {
        
    }
}
