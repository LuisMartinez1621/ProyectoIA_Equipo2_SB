using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    // ImageTarget
    public GameObject imageTarget;

    // Cilindro
    public GameObject cylinder;

    // Cubo
    public GameObject cube;

    // Array de cilindros
    GameObject[,] cylinders = new GameObject[3,3];

    // Array de los ingredientes
    GameObject[,] ingredients = new GameObject[3, 3];

    // Start is called before the first frame update
    void Start()
    {
        // Scale and position

        // Ciclo que genera las bases de los ingredientes
        for (int x = 0; x < 3; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                // Se crea una instancia de un objeto "Cylinder"
                cylinders[x, y] = Instantiate(cylinder, imageTarget.transform.position, new Quaternion(0,0,0,0));

                // Se asigna el ImageTarget como padre de la base
                cylinders[x, y].transform.parent = imageTarget.transform;

                // Se ajusta la escala
                //cylinders[x, y].transform.localScale = scale;

                // Se ajusta la posición
                cylinders[x, y].transform.localPosition = new Vector3(x - 1, 0.1f, y - 1);
            }
        }

        // Ingredientes!
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                // Se crea una instancia de un objeto "Cylinder"
                ingredients[x, y] = Instantiate(cube, cylinders[x, y].GetComponent<Transform>().transform.position, new Quaternion(0, 0, 0, 0));

                // Se asigna el ImageTarget como padre de la base
                ingredients[x, y].transform.parent = cylinders[x, y].GetComponent<Transform>().transform;

                // Se ajusta la escala
                //ingredients[x, y].transform.localScale = scale;

                // Se ajusta la posición
                ingredients[x, y].transform.localPosition = new Vector3(0, 20f, 0);
            }
        }

        /*for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                // Creando los cubos
                ingredients[cubeCount] = Instantiate(cube, cylinders[x, y].GetComponent<Transform>().transform.position, new Quaternion(0, 0, 0, 0));
                ingredients[cubeCount].transform.parent = cylinders[x, y].GetComponent<Transform>().transform;
                ingredients[cubeCount].transform.localScale = scaleCube;
                ingredients[cubeCount].transform.localPosition = new Vector3(0, 1f, 0);

                cubeCount++;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
