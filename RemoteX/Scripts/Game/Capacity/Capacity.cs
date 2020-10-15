using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Capacity : MonoBehaviour
{
    private TokenSpace tokenSpace;
    private CapacityBar capacityBar;
    private int limit = 20;

    [Header("Capacity info")]
    public bool isGameOver = false;
    public Text capacityText;

    private Color[] lastColors;

    private void Awake()
    {
        lastColors = new Color[0];
        capacityBar = FindObjectOfType<CapacityBar>();
        tokenSpace = FindObjectOfType<TokenSpace>();
    }
    private void Update()
    {
        capacityText.text = capacityBar.transform.childCount + " / " + limit.ToString();
        CheckGameStatus();
    }


    private void CheckGameStatus()
    {
        if (capacityBar.transform.childCount >= limit)
        {
            isGameOver = true;
        }

        if (!isGameOver)
        {
            testGenerator();
        }
    }   


    public void SetLimit(int l)
    {
        limit = l; //-- actualizamos
        capacityBar.ReSize(limit);
    }


    private void testGenerator()
    {
        bool hasChanges = CheckColors(tokenSpace.tok_col);

        if (hasChanges)
        {
            lastColors = tokenSpace.tok_col;

            int lastQty = capacityBar.transform.childCount;
            for (int k = 0; k < lastQty; k++)
            {
                capacityBar.DeleteItem(k);
            }
            foreach (var c in lastColors)
            {
                capacityBar.CreateItem(c);
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
            if (cols[x] != lastColors[x])
            {
                hasChanges = true;
            }
        }
        return hasChanges;
    }
}