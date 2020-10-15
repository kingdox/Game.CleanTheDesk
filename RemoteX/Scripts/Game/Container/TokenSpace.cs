using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenSpace : MonoBehaviour
{

    public Token[] tokens;

    public Color[] tok_col;

    private void Update()
    {
        UpdateChildArray();
    }


    private void UpdateChildArray()
    {
        int count = transform.childCount;
        Token[] recipe_t = new Token[count];
        Color[] recipe_c = new Color[count];

        for (int x = 0; x < count; x++)
        {
            Transform g_tr = transform.GetChild(x);

            Token g_t = g_tr.GetComponent<Token>();

            Color g_c = g_tr.GetComponent<Image>().color;

            recipe_t[x] = g_t;
            recipe_c[x] = g_c;
        }
        tokens = recipe_t;
        tok_col = recipe_c;
    }

}
