using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PowerBar : MonoBehaviour
{

    private GridLayoutGroup gridLayoutGroup;
    private readonly  float wanted_h = 32; // 32
    public int limit = 10;

    private void Awake()
    {
        limit = 10; // por defecto
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    void Update()
    {
        ReSize();
    }


    private void ReSize()
    {

        float new_h = Screen.height / wanted_h;
        float width_Spacing = (limit - 1) * gridLayoutGroup.spacing.x;// calcula el espacio y descontando el de los laterales
        float new_w = (Screen.width / limit) - width_Spacing;
        gridLayoutGroup.padding.left = Mathf.RoundToInt(gridLayoutGroup.spacing.x * 2);
        gridLayoutGroup.cellSize = new Vector2(new_w, new_h );

    }

}
