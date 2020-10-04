using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipation : MonoBehaviour
{
    private readonly Data data = new Data();
    private GameObject[][] areas;//muestra matrix
    private GameObject[] equipAreas;
    //[Header("Equipment")]

   

    private void Awake()
    {
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

    void Start()
    {
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



    //public void SetRotation(int index , bool condition = false)
    //{

    //    for (int j = 0; j < areas[index].Length; j++)
    //    {
    //        areas[index][j].GetComponent<Rotation>().enabled = condition;
    //        areas[index][j].transform.localRotation = Quaternion.Euler(0, 0, 0);

    //    }
    //}
}