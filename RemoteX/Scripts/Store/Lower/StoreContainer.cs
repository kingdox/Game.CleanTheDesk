using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class StoreContainer : MonoBehaviour
{
    private readonly Data data = new Data();
    private Equipation equipation;


    private int countProduct;
    private GameObject[] storeSlots;
    private GameObject[] tokenSlots;

    [Header("Create")]
    public GameObject tokenPrefab;
    public GameObject tokenStore;

    [Header("Information")]
    public string lastStore;


    private void Awake()
    {
        equipation = FindObjectOfType<Equipation>();

        lastStore = "shapes";
        countProduct = gameObject.transform.childCount;

        SetSlots();
    }

    private void SetSlots()
    {
        storeSlots = new GameObject[countProduct];
        tokenSlots = new GameObject[countProduct];

        for (int i = 0; i < countProduct; i++)
        {
            storeSlots[i] = gameObject.transform.GetChild(i).gameObject;
            tokenSlots[i] = tokenStore.transform.GetChild(i).gameObject;
            storeSlots[i].name = "sS [ " + i + " ]";
            tokenSlots[i].name = "tS [ " + i + " ]";
        }
    }


    /// <summary>
    /// Cambia toda la store al asignado, activando y desactivando
    /// los hijos del store para mostrar lo deseado
    /// </summary>
    public void ChangeTo(string type="shapes")//por defecto es shapes
    {
        foreach (GameObject tS in tokenSlots)
        {
            OnOffChilds(tS, type);
        }
        equipation.AreaOnOff(type);

        lastStore = type;
    }

    private void OnOffChilds(GameObject ts, string activeName)
    {
        for (int i = 0; i < ts.transform.childCount; i++)
        {
            GameObject child = ts.transform.GetChild(i).gameObject;
            child.SetActive(child.name == activeName);
        }
    }

   





    public void CreatePrefabs_Shapes(int[] shapes)
    {
        for (int x = 0; x < countProduct; x++)
        {

            GameObject prefab = Instantiate(tokenPrefab, tokenSlots[x].transform ).gameObject;

            prefab.name = "shapes";

            Image prefImg = prefab.GetComponent<Image>();
            Sprite prefSpr = Resources.Load<Sprite>(data.path_Img + data.pathShapes[shapes[x]]);
            prefImg.sprite = prefSpr;

        }
    }



    public void CreatePrefabs_Powers(int[] powers)
    {
      
    }

    public void CreatePrefabs_Palletes(int[] palletes)
    {
        for (int x = 0; x < countProduct; x++)
        {

            GameObject prefab = Instantiate(tokenPrefab, tokenSlots[x].transform).gameObject;

            prefab.name = "palletes";

            Image pref_img = prefab.GetComponent<Image>();


            Color pref_col = data.palletes[x];
            pref_img.color = pref_col;


            Sprite pref_spr = Resources.Load<Sprite>(data.path_Img + data.pathShapes[0]);
            pref_img.sprite = pref_spr;

        }
    }
}