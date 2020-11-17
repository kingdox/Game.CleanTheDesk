using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//TODO cambiar el noombre a servicio general de int ? o etc
public class ColorS
{

    /*
     Con este podrás resolver cosas de colores, dejando mas limpio otros scripts...
     */

    //TODO mejorrar logica aqui para usarlo en los 3


    /// <summary>
    /// Genera aleatoriamente en un rango puesto
    /// 
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="stored"></param>
    /// <returns>Retorna stored pero con nuevos valores tomando en cuenta las "actual"</returns>
    public int[] ReOrder(int[] actual, int[]store, int length)
    {
        Debug.Log($"Longitud {length}");

        int[] newStore = store;
        
        /*
            //condiciones, se cambia uno por uno, poniendole un int random 0,
            length y, si este luego no es igual a ninguno de la store (Excepto el mismo)
            o actual entonces es libre.
        */

        bool isDiferent = false;

        for (int x = 0; x < newStore.Length; x++)
        {
            isDiferent = false;
            while (!isDiferent)
            {
                newStore[x] = Random.Range(0, length);

                isDiferent =
                    LookDifferences(newStore[x], actual)
                    && LookDifferences(newStore[x], newStore, x);
                

            }
            Debug.Log($"Color {x} ==> {newStore[x]}");
        }
        


        return newStore;
    }



    private bool LookDifferences( int looked, int[] toLook, int indexEception = -1)
    {

        for (int j = 0; j < toLook.Length; j++)
        {
            if (looked == toLook[j] && (indexEception == -1 || j != indexEception)  )
            {
                return false;
            }
        }

        return true;
    }

}
