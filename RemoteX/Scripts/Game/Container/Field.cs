using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    [Header("Container settings")]
    public bool hasContainer;


    [Header("Field info")]
    public Token[] tokenChilds;
    private Stack<Token> stack = new Stack<Token>();


    private void Update()
    {
        UpdateTokens();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasContainer)
        {
            return;
        }
        if (collision.CompareTag("Token"))
        {
            Token tok = collision.GetComponent<Token>();
            if (tok.isNew)
            {
                tok.isNew = false;
                stack.Push(tok);
                UpdateTokens();

            }
        }
    }


    //hay que quitar los que sean missing...
    private void UpdateTokens()
    {

        //tokenChilds;
        Stack<Token> recipe_stack = new Stack<Token>();
        Token[] recipe_token = stack.ToArray();

        //esta haciendo un push alreves....
        //los push siempre van al inicio, en vez de al final...
        for (int x = recipe_token.Length; x > 0; x--)
        {
            if (!!recipe_token[x- 1])
            {
                recipe_stack.Push(recipe_token[x - 1]);
            }
            
        }
        stack = recipe_stack;
        tokenChilds = recipe_stack.ToArray();
        VerifyLastToken();
    }


    /// <summary>
    /// Partiendo de que [0] es la ultima ficha que poseemos podemos saber la ultima..., en caso de que
    /// sea agarrada o, no este en su posición, se puede permanecer como enable
    /// </summary>
    private void VerifyLastToken()
    {
        for (int x = 0; x < tokenChilds.Length; x++)
        {
            tokenChilds[x].enabled =
                x == 0
                || tokenChilds[x].isDraggin
                || tokenChilds[x].posToGo != tokenChilds[x].transform.position;
        }
    }
}