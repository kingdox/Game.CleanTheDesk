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
                UpdateTokens(tok);
            }
        }
    }


    //hay que quitar los que sean missing...
    private void UpdateTokens(Token t_new = null)
    {
        //stack.Push(tok);TODO

        //tokenChilds;
        Stack<Token> recipe_stack = new Stack<Token>();
        Token[] recipe_token = stack.ToArray();


        //esta haciendo un push alreves....
        //los push siempre van al inicio, en vez de al final...
        for (int x = recipe_token.Length; x < 0; x--)
        {

            
        }


        foreach (var t in recipe_token)
        {

            if (!!t)
            {
                recipe_stack.Push(t);
            }
        }


        stack = recipe_stack;
        tokenChilds = recipe_stack.ToArray();

    }







}


// TODO ten actualizado aqui 

///// <summary>
///// Hace que poseas un array con los tokens actualizados
///// </summary>
//private void UpdateTokenArray()
//{
//    //revisa el arreglo y si hay una missing se va
//    Token[] tokens  = stack.ToArray();
//    Stack<Token> token_stack = new Stack<Token>();

//    foreach (var t in tokens)
//    {
//        if (!!t)
//        {
//            token_stack.Push(t);
//        }
//    }

//    //Entrega lo mas actualizado...
//    tokenChilds = token_stack.ToArray();
//}