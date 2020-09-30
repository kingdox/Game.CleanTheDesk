using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class StoreContainer : MonoBehaviour
{
    private readonly Data data = new Data();

    public GameObject tokenPrefab;
    public GameObject tokenStore;

    public GameObject[] storeChilds;

    // Cargado por StoreManager
    public void CreatePrefabs_IMG( int[] lastStore )
    {
        storeChilds = new GameObject[ gameObject.transform.childCount ] ;
        GameObject[] tokenStoreChilds = new GameObject[storeChilds.Length]; // deben de ser iguales

        


        for (int i = 0; i < storeChilds.Length; i++)
        {
            tokenStoreChilds[i] = gameObject.transform.GetChild(i).gameObject;
            //Transform slot = gameObject.transform.GetChild(i);

            GameObject prefab = Instantiate(tokenPrefab, tokenStoreChilds[i].transform);

            // Edit Section

            prefab.name = "Token["+i+"]";

            Image prefImg = prefab.GetComponent<Image>();
            Sprite prefSpr = Resources.Load<Sprite>(data.path_Img + data.pathShapes[lastStore[i]]);
            prefImg.sprite = prefSpr; //aqui le otorgamos el sprite guardado del store
            //prefImg.color = data.palletes[Random.Range(0, data.palletes.Length)];
            //
            storeChilds[i] = prefab;
        }
    }
}