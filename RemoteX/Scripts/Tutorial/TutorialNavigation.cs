using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialNavigation : MonoBehaviour
{

    [Header("Navigation settings")]
    public int activePage = 0; //
    public Text pageText;
    public GameObject[] pages = new GameObject[4];



    private void Awake()
    {
        SetPage();
    }

    public void NavigateTo(bool direction)
    {

        if (direction)
        {
            activePage = activePage != 0
             ? --activePage
             : (pages.Length - 1);
        }
        else
        {
            activePage = activePage != (pages.Length - 1)
              ? ++activePage
              : 0;
        }

        SetPage();
    }




    private void SetPage()
    {
        for (int x = 0; x < pages.Length; x++)
        {
            pages[x].SetActive(x == activePage);
        }

        pageText.text = activePage.ToString();
    }

}
