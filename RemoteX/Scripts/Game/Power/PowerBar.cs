using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PowerBar : MonoBehaviour
{
    private Image img;
    private GridLayoutGroup gridLayoutGroup;
    private readonly  float wanted_h = 32; // 32
    public int limit = 10;
    public GameObject powerItem_prefab;

    private void Awake()
    {
        img = GetComponent<Image>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    void Update()
    {
        ReSize();
        ReachChecker();
    }


    private void ReachChecker()
    {
        int countChilds = gameObject.transform.childCount;

        if (countChilds == limit)
        {
            img.color = new Color(0, 0, 0, 0);
            //destruye sus hijos
            //TODO Entender por que esto es bucle infinito...
            //while (gameObject.transform.childCount != 0)
            //{
            //    GameObject obj = transform.GetChild(0).gameObject;
            //    Destroy(obj);
            //}
        }
        else
        {

        }
    }



    private void ReSize()
    {

        float new_h = Screen.height / wanted_h;
        //float width_Spacing = (limit - 1) * gridLayoutGroup.spacing.x;// calcula el espacio y descontando el de los laterales
        float new_w = (Screen.width / limit);// - width_Spacing;
        gridLayoutGroup.padding.left = Mathf.RoundToInt(gridLayoutGroup.spacing.x * 2);
        gridLayoutGroup.cellSize = new Vector2(new_w, new_h );
    }

}
