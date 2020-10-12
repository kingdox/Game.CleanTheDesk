using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapacityBar : MonoBehaviour
{
    private Image img; //TODO esta haremos que cambie de colores cuando quede poca vida...
    private GridLayoutGroup gridLayoutGroup;
    private readonly float wanted_h = 32; // 32 es el tamaño de las img en teoria...

    private RectTransform rectTransform;

    [Header("CapacityBar info")]
    public GameObject capacityItem_prefab;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

    }

    public void ReSize(int limit)
    {
        float objWidth = Screen.width * (rectTransform.anchorMax.x - rectTransform.anchorMin.x);
        float new_h = Screen.height / wanted_h;
        float new_w = objWidth / limit;

        gridLayoutGroup.padding.left = Mathf.RoundToInt(gridLayoutGroup.spacing.x * 2);
        gridLayoutGroup.cellSize = new Vector2(new_w, new_h);
    }

    //Aqui coloca el color respectivo
    public void SetColor(Color col, int index)
    {
        Transform trans = gameObject.transform.GetChild(index) ;
        Image trans_img = trans.GetComponent<Image>();
        trans_img.color = col;
    }

    public void CreateItem(Color col)
    {
        GameObject obj = Instantiate(capacityItem_prefab, gameObject.transform);
        Image obj_img = obj.GetComponent<Image>();
        obj_img.color = col;
    }

    public void DeleteItem(int index)
    {
        GameObject obj = gameObject.transform.GetChild(index).gameObject;
        Destroy(obj);
    }
}