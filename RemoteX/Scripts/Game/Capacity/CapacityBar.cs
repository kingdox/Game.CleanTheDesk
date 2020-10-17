﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapacityBar : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;
    private readonly float wanted_h = 32; // 32 es el tamaño de las img en teoria...


    [Header("CapacityBar info")]
    public GameObject capacityItem_prefab;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

    }

    public void ReSize(int limit)
    {
        float new_h = Screen.height / wanted_h;

        //ancho del objeto basado en el screen
        float objWidth = Screen.width * (rectTransform.anchorMax.x - rectTransform.anchorMin.x);
        float new_w = (objWidth / limit) - gridLayoutGroup.spacing.x;
        gridLayoutGroup.cellSize = new Vector2(new_w, new_h);
    }

    public void CreateItem(Color col)
    {
        GameObject obj = Instantiate(capacityItem_prefab, gameObject.transform);
        Image obj_img = obj.GetComponent<Image>();
        obj_img.color = col;

        Image img = transform.GetComponent<Image>();
        img.color = new Color(col.r, col.b, col.g, 0.2f);
    }

    public void DeleteItem(int index)
    {
        GameObject obj = gameObject.transform.GetChild(index).gameObject;
        Destroy(obj);
    }
}