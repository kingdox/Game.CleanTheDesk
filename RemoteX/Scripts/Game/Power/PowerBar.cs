using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PowerBar : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;
    private readonly  float wanted_h = 32; // 32

    [Header("PowerBar info")]
    public int limit = 10;
    public int powerCount = 0;
    public GameObject powerItem_prefab;

    private void Awake()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        ReSize();
        CheckChanges();
    }

    private void ReSize()
    {
        float new_h = Screen.height / wanted_h;

        //ancho del objeto basado en el screen
        float objWidth = Screen.width * (rectTransform.anchorMax.x - rectTransform.anchorMin.x);
        float new_w = (objWidth / limit) - gridLayoutGroup.spacing.x - (gridLayoutGroup.padding.right);//gridLayoutGroup.padding.left +
        gridLayoutGroup.cellSize = new Vector2(new_w, new_h);
    }

    private void CheckChanges()
    {
        if (powerCount != transform.childCount)
        {
            powerCount = powerCount > limit ? limit : powerCount;

            if (powerCount < transform.childCount)
            {
                DeleteChilds(transform.childCount - powerCount);
            }
            else
            {
                CreateChilds(powerCount - transform.childCount);
            }
        }
    }

    private void DeleteChilds(int deleteCount = 1)
    {
        for (int i = 0; i < deleteCount; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            Destroy(obj);
        }

    }


    private void CreateChilds(int createCount = 1)
    {

        for (int i = 0; i < createCount; i++)
        {
            GameObject obj = Instantiate(powerItem_prefab, gameObject.transform);
        }
    }
}
