using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour
{
    private readonly Data data = new Data();

    public GameObject menuTokenPrefab;
    /*
     * MENU
     * 
     * -Permite saber que elección tomamos de a donde dirigirnos al poner una ficha aca (lo cual nos redirige y todo eso
     * -Genera Tokens alrededor de el que estarán rotando, estas pueden ser agarrables  y puestas en el contenedor, al hacerlo dicha ficha se teleporta a su lugar basado en la rotacion de el detector
     * 
     */

    private readonly Vector3[] PositionsOfPrefabs = new Vector3[4] {
        new Vector3(1.5f, 0.2f, 90),
        new Vector3(-1.5f, 0.2f, 90),
        new Vector3(0, 1.8f, 90),
        new Vector3(0, -1.3f, 90),

        //new Vector3(-1f, 1f, 90),
        //new Vector3(1f, -1f, 90),
        //new Vector3(1f, 1f, 90),
        //new Vector3(-1f, -1f, 90)
    };

    void Start()
    {
        StartCoroutine(CreatePrefabs(0));
    }




    IEnumerator CreatePrefabs(float time)
    {
        yield return new WaitForSeconds(time);

        for (int j = 0; j < PositionsOfPrefabs.Length; j++)
        {
          GameObject t =   Instantiate(menuTokenPrefab, PositionsOfPrefabs[j], gameObject.transform.rotation, gameObject.transform);

            Image img = t.GetComponent<Image>();
            int randomNumber = Random.Range(0, data.pathShapes.Length);
            Sprite sp = Resources.Load<Sprite>(data.path_Img + data.pathShapes[randomNumber]);
            Color col = data.palletes[Random.Range( 0, data.palletes.Length)];

            img.sprite = sp;
            img.color = col;
            //Debug.Log("Position: " + data.pathImg + data.pathShapes[randomNumber]);

        }
    }


    private void Update()
    {
        
        gameObject.transform.Rotate(0.0f, 0.0f, 45 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detect(collision.gameObject);
    }

    public void Detect(GameObject token)
    {

        //Debug.Log(token.name);

        string text = token.name;

        switch (text)
        {
            case "Music":

                break;
            case "Play":
                SceneManager.LoadScene(1);

                break;
            case "Shop":
                break;

            default:
                // cualquier otro no importante...
                break;
        }
        Destroy(token);
    }

    
}