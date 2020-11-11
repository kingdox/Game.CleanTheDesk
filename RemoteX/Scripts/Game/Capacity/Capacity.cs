using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capacity : MonoBehaviour
{
    private TokenSpace tokenSpace;
    private CapacityBar capacityBar;

    [Header("Capacity info")]
    public bool isGameOver = false;
    public Text capacityText;
    public int limit = 20;

    private Color[] lastColors;

    private void Awake()
    {
        lastColors = new Color[0];
        capacityBar = FindObjectOfType<CapacityBar>();
        tokenSpace = FindObjectOfType<TokenSpace>();
    }
    private void Update()
    {
        UpdateCapacityText();
        CheckGameStatus();
    }
    private void UpdateCapacityText()
    {
        int fixedCount = capacityBar.transform.childCount > limit
            ? capacityBar.transform.childCount - limit
            : capacityBar.transform.childCount
            ;

        capacityText.text = fixedCount + " / " + limit.ToString();

        //si la cantidad de fichas esta alrededor del 25% del limite entonces titilea
        float leftSpace = (float)+limit - fixedCount;
        float percent = (float)+limit / 100 * 25;

        bool condition = leftSpace <= percent;
       

        capacityText.color = condition
        ? new Color(1, 0, 0, 1)
        : new Color(0, 0, 0, 0.5f)
        ;
        //parentImg_capacityText.color = condition
        //? new Color(1, 1, 0, 1)
        //: new Color(1, 1, 1, 1)
        //;
    }

    private void CheckGameStatus()
    {
        if (capacityBar.transform.childCount >= limit)
        //if (tokenSpace.tok_col.Length > limit)
        {
                isGameOver = true;
        }


        if (!isGameOver)
        {
            CheckForChanges();
        }
    }   


    public void SetLimit(int l)
    {
        limit = l; //-- actualizamos
        capacityBar.ReSize(limit);
    }


    private void CheckForChanges()
    {
        bool hasChanges = CheckColors(tokenSpace.tok_col);

        if (hasChanges)
        {
            lastColors = tokenSpace.tok_col;
            int colorsOnCreation = lastColors.Length > limit ? limit : lastColors.Length;

            int lastQty = capacityBar.transform.childCount;

            //Limpiamos
            for (int k = 0; k < lastQty; k++)
            {
                capacityBar.DeleteItem(k);
            }
            //Creamos
            for (int x = 0; x < colorsOnCreation; x++)
            {
                capacityBar.CreateItem(lastColors[x]);
            }
        }
    }
    public bool CheckColors(Color[] cols)
    {
        if (cols.Length != lastColors.Length)
        {
            return true;
        }

        bool hasChanges = false;

        for (int x = 0; x < cols.Length; x++)
        {
            if (!cols[x].Equals(lastColors[x]))
            {
                hasChanges = true;
            }
        }
        return hasChanges;
    }
}