using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipation : MonoBehaviour
{
    private readonly Data data = new Data();
    private StoreContainer storeContainer;
    private StoreManager storeManager;
    private GameObject[][] areas;//muestra matrix
    private GameObject[] equipAreas;
    //[Header("Equipment")]

   

    private void Awake()
    {
        storeContainer = FindObjectOfType<StoreContainer>();
        storeManager = FindObjectOfType<StoreManager>();

        areas = new GameObject[transform.childCount][];// contamos la cantidad de objetos.
        equipAreas = new GameObject[areas.Length];



        for (int x = 0; x < areas.Length; x++)
        {
            Transform transfArea = transform.GetChild(x);
            equipAreas[x] = transfArea.gameObject;//set equipAreas;
            equipAreas[x].name = data.storeTypes[x];

            areas[x] = new GameObject[transfArea.childCount];

            for (int j = 0; j < areas[x].Length; j++)
            {
                areas[x][j] = transfArea.GetChild(j).gameObject;
            }
        }
    }

    //los que no sean del nombre son disabled en rotation
    public void AreaOnOff(string nameArea)
    {
        //Debug.Log("Set On: " + nameArea);

        for (int x = 0; x < equipAreas.Length; x++)
        {
            SetRotation2(areas[x], equipAreas[x].name == nameArea );
        }
    }


    public void SetRotation2(GameObject[] area  , bool condition = false)
    {

        for (int j = 0; j < area.Length; j++)
        {
            area[j].GetComponent<Rotation>().enabled = condition;
            area[j].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    



    /// <summary>
    /// slot_index es el sitio donde se extrajo, util para saber donde cambiar el numero para datapass
    /// 
    /// </summary>
    /// <param name="equiped"></param>
    /// <param name="token"></param>
    /// <param name="slot_index"></param>
    public void ChangeEquip(GameObject equiped, GameObject token)
    {

        string type = storeContainer.lastStore; //tipo*
        int storeIndex = FindSlotIndex(token.transform);
        int equipedOfType = FindMyIndex(equiped);

        int last_equipedValue = -1;
        Image equip_img = equiped.GetComponent<Image>();
        Image token_img = token.GetComponent<Image>();



        //Cada quien tendrá una función con su busqueda especifica
        switch (type)
        {
            case "shapes":

                last_equipedValue = SearchIndexOf_Shapes(data.pathShapes, equip_img.sprite.name);

                //Hace el cambio
                Sprite recipe_spr = equip_img.sprite;
                equip_img.sprite = token_img.sprite;
                token_img.sprite = recipe_spr;

                break;

            case "powers":

                last_equipedValue = SearchIndexOf_Powers();
                break;

            case "palletes": //TODO, revisar que sirva

                last_equipedValue = SearchIndexOf_Palletes(data.palletes, equip_img.color);

                //Hace el cambio
                Color recipe_col = equip_img.color;
                equip_img.color = token_img.color;
                token_img.color = recipe_col;
                break;

            default:
                //No encontró....
                Debug.LogError("Error en el tipo...");
                break;
        }


        Debug.Log("El index del sprite equipado era: " + last_equipedValue);


        //TODO
        storeManager.ChangesOn(last_equipedValue, storeIndex, type, equipedOfType);
    }





    //Helper Functions________________________
    private int SearchIndexOf_Shapes(string[] toSearch, string search)
    {
        int index = -1; // si es -1 no encontró
        for (int x = 0; x < toSearch.Length; x++)
        {
            if (toSearch[x] == search)
            {
                index = x;
            }
        }
        return index;
    }
    private int SearchIndexOf_Powers()
    {
        return -1;
    }//TODO
    private int SearchIndexOf_Palletes(Color[] toSearch, Color search)
    {
        int index = -1; // si es -1 no encontró

        for (int x = 0; x < toSearch.Length; x++)
        {
            if (toSearch[x] == search)
            {
                index = x;
            }
        }
        return index;
    }

    private int FindSlotIndex(Transform token_transf)
    {

        Transform slotContainer = token_transf.parent.parent;
        int count_Slots = slotContainer.childCount;
        int slot_index = -1;

        for (int x = 0; x < count_Slots; x++)
        {

            if (slotContainer.GetChild(x).name == token_transf.parent.name)
            {
                slot_index = x;
            }
        }

        return slot_index;
    }
    /// <summary>
    /// Encuentra el parent de este
    /// </summary>
    private int FindMyIndex(GameObject obj)
    {
        Transform parent_trans = obj.transform.parent;

        int index = -1;

        for (int i = 0; i < parent_trans.childCount; i++)
        {
            if (parent_trans.GetChild(i).name == obj.name)
            {

                index = i;
            }

        }
        Debug.Log("Detection on: " + index);
        return index;
    }
}