using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    // ImageTarget donde se generará todo
    public GameObject imageTarget;

    // Cilindros que serán la base de los ingredientes
    public GameObject cylinder;

    // Interfaz que se abre al picar un ingrediente
    public GameObject countUI;

    // Centro de todo
    public GameObject center;
    GameObject centerBase;

    // Arreglo de dos dimensiones de los cilindros
    GameObject[] cylinders;

    // Arreglo de dos dimensiones de los ingredientes
    GameObject[] ingredients;

    // TODOS LOS INGREDIENTES!
    Ingredients2 levels;

    // Lista donde se guardarán los ingredientes del nivel
    GameObject[] list;

    // Start is called before the first frame update
    void Start()
    {
        // Se obtiene el script de los ingredientes
        levels = GetComponent<Ingredients2>();

        // Se recibe la lista de los ingredientes
        list = levels.GetRecipe();

        // Se inicializan los arrays dependiendo de la cantidad de ingredientes
        cylinders = levels.SetLength();
        ingredients = levels.SetLength();

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
        
    }

    // Método que genera los cilindros base
    void GenerateBase()
    {
        // Variable para centrar las bases
        float centerThing = SetCenter();

        // Ciclo para generar las bases de los ingredientes
        for(int x = 0; x < cylinders.Length; x++)
        {
            // Se crea una instancia de un objeto "Base"
            cylinders[x] = Instantiate(cylinder, imageTarget.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));

            // Se asigna el ImageTarget como padre de la base
            cylinders[x].transform.parent = imageTarget.transform;

            // Se ajusta la posición
            cylinders[x].transform.localPosition = new Vector3((x - centerThing) / 3f, 0f, 0f);
        }
        
        // Código donde se crea un centro invisible al inicio para aparecer el ingrediente en grande
        centerBase = Instantiate(cylinder, imageTarget.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        centerBase.transform.parent = imageTarget.transform;
        centerBase.transform.localPosition = new Vector3(0f, 0f, 0f);
        centerBase.SetActive(false);
    }

    // Método que genera los ingredientes
    void GenerateIngredients()
    {
        // Ciclo para colocar los ingredientes
        for(int x = 0; x < ingredients.Length; x++)
        {
            // Se crea una instancia de un ingrediente (en orden de la lista de ingredientes
            ingredients[x] = Instantiate(list[x], cylinders[x].GetComponent<Transform>().transform.position, Quaternion.Euler(new Vector3(-90, 90, 0)));

            // Se asigna una "Base" como padre del ingrediente (para que no se mueva de su lugar
            ingredients[x].transform.parent = cylinders[x].GetComponent<Transform>().transform;

            // Se ajusta la posicion (3 en Z para que queden mas o menos arriba de la base)
            ingredients[x].transform.localPosition = new Vector3(0, 0, 3f);

            // Se asigna el script de los gestos del nivel 2
            ingredients[x].AddComponent<Gestures2>();

            // Se asigna la posición
            ingredients[x].GetComponent<Gestures2>().position = x;
        }
        
        // Código donde se crea la instancia de un ingrediente X para tenerlo oculto
        temp = Instantiate(list[0], centerBase.GetComponent<Transform>().transform.position, Quaternion.Euler(new Vector3(-90, 90, 0)));
        temp.transform.parent = centerBase.GetComponent<Transform>().transform;
        temp.transform.localPosition = new Vector3(0, 0, 1.8f);
        temp.AddComponent<Gestures2>();
        centerBase.transform.localScale += new Vector3(.08f, .08f, .08f);
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

    // Cosas para acomodar los ingredientes centrados
    float SetCenter()
    {
        switch(cylinders.Length)
        {
            case 5: return 2f;
            case 6: return 2.5f;
            case 7: return 3f;
            default: return 0f;
        }
    }



    // Cosas siniestras
    GameObject temp;
    int tempPosition;

    // Método siniestro para ocultar todo!
    public void DissapearIngredients(int position)
    {
        // Se activa la interfaz para seleccionar cantidad
        countUI.SetActive(true);

        // Se pone valor a la posición del ingrediente que se seleccionó
        tempPosition = position;

        // Se inactivan todos los ingredientes
        foreach(GameObject bases in cylinders)
        {
            bases.SetActive(false);
        }

        // Código para reemplazar el modelo, materiales y escala del objeto que aparecerá en grande
        temp.GetComponent<MeshFilter>().mesh = ingredients[position].GetComponent<MeshFilter>().mesh;
        temp.GetComponent<MeshRenderer>().materials = ingredients[position].GetComponent<MeshRenderer>().materials;
        temp.GetComponent<Transform>().localScale = ingredients[position].GetComponent<Transform>().localScale;

        // Aparece el ingrediente en grande
        centerBase.SetActive(true);

        // Se asigna el estado al ingrediente para que pueda girar
        temp.GetComponent<Gestures2>().status = 1;
    }

    // Método aún más siniestro para aparecer todo!
    public void AppearIngredients()
    {
        // Se oculta la interfaz para seleccionar cantidad
        countUI.SetActive(false);

        // Se activan los ingredientes
        foreach (GameObject bases in cylinders)
        {
            bases.SetActive(true);
        }

        // Desaparece el ingrediente en grande
        centerBase.SetActive(false);

        // Se asigna el estado al ingrediente para que no pueda girar
        ingredients[tempPosition].GetComponent<Gestures2>().status = 0;
    }
}
