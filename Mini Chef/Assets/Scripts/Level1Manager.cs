using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    // ImageTarget donde se generará todo
    public GameObject imageTarget;

    // Cilindros que serán la base de los ingredientes
    public GameObject cylinder;

    // Arreglo de dos dimensiones de los cilindros
    GameObject[,] cylinders = new GameObject[3,3];

    // Arreglo de dos dimensiones de los ingredientes
    GameObject[,] ingredients = new GameObject[3, 3];

    // TODOS LOS INGREDIENTES!
    public GameObject boteMayonesa;
    public GameObject boteMoztaza;
    public GameObject lechuga;
    public GameObject pan;
    public GameObject queso;

    // Lista donde se guardarán los ingredientes del nivel
    GameObject[] list;


    // Start is called before the first frame update
    void Start()
    {
        // LISTA DE PRUEBA, NO SERÁ SIEMPRE ASÍ
        list = new GameObject[]
        {
            boteMayonesa,
            boteMoztaza,
            lechuga,
            pan,
            queso,
            boteMoztaza,
            queso,
            pan,
            lechuga
        };

        // "Randomizador" de la lista de ingredientes
        RandomArray(list);

        // Llamada al método que generará la base de los ingredientes
        GenerateBase();

        // Llamada al método que pondrá en su posición a los ingredientes del nivel
        GenerateIngredients();
    }

    // Update is called once per frame
    void Update()
    {
        // AQUÍ NO PONGAN NADA (de momento)
    }

    // Método que genera los cilindros base
    void GenerateBase()
    {
        // Ciclo anidado que genera las bases de los ingredientes
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                // Se crea una instancia de un objeto "Base"
                cylinders[x, y] = Instantiate(cylinder, imageTarget.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

                // Se asigna el ImageTarget como padre de la base
                cylinders[x, y].transform.parent = imageTarget.transform;

                // Se ajusta la posición
                cylinders[x, y].transform.localPosition = new Vector3(x - 1, 0.1f, y - 1);
            }
        }
    }

    // Método que genera los ingredientes
    void GenerateIngredients()
    {
        // Contador para la lista de los ingredientes
        int c = 0;

        // Ciclo anidado para colocar los ingredientes
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                // Se crea una instancia de un ingrediente (en orden de la lista de ingredientes)
                ingredients[x, y] = Instantiate(list[c], cylinders[x, y].GetComponent<Transform>().transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

                // Se asigna una "Base" como padre de la base (para que no se muevan de su lugar)
                ingredients[x, y].transform.parent = cylinders[x, y].GetComponent<Transform>().transform;

                // Se ajusta la posición (3 en Z para que queden más o menos arriba de la base)
                ingredients[x, y].transform.localPosition = new Vector3(0, 0, 3f);

                // Aumento del contador
                c++;
            }
        }
    }

    // Método robado de por ahí que me randomiza un arreglo
    void RandomArray(GameObject[] items)
    {
        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = Random.Range(i, items.Length);
            GameObject temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
