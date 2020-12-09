using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour
{
    // Referencia a las variables
    GameVariables gameVariables;

    // ImageTarget donde se generará todo
    public GameObject imageTarget;

    // Cilindros que serán la base de los ingredientes
    public GameObject cylinder;

    // Interfaz que se abre al picar un ingrediente
    public GameObject countUI;

    // Pantalla de resultados
    public GameObject resultScreen;

    // Cuadros de las imágenes
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    // Botones de suma y resta
    public GameObject buttonAdd;
    public GameObject buttonSub;

    // Cosa de los puntos
    public Text pointsText;
    public Text correctText;
    public Text incorrectText;

    // Cosas de los tiempos
    public Text timer;
    float time;
    float textTime;

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

    // Lista de los íconos
    System.String[] iconList;

    // Lista de cantidades
    float[] quantityList;

    // Start is called before the first frame update
    void Start()
    {
        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();

        // Se obtiene el script de los ingredientes
        levels = GetComponent<Ingredients2>();

        // Se recibe la lista de los ingredientes del nivel
        levels.GetRecipe();

        // Se consiguen las listas del script de los ingredientes del nivel 2
        list = levels.array;
        iconList = levels.icons;
        quantityList = levels.quantity;

        // Se inicializan los arrays dependiendo de la cantidad de ingredientes
        cylinders = levels.SetLength();
        ingredients = levels.SetLength();

        // "Randomizador" de la lista para el nivel 2
        RandomArray(list, iconList, quantityList);

        // Cosa
        IngredientCount();

        // Llamada al método que generará la base de los ingredientes
        GenerateBase();

        // Llamada al método que pondrá en su posición a los ingredientes del nivel
        GenerateIngredients();

        // Variable del tiempo
        time = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO PARA EL TEMPORIZADOR!!!
        time -= Time.deltaTime;
        textTime -= Time.deltaTime;
        timer.text = time.ToString("f0");

        if (time < 0)
        {
            resultScreen.GetComponent<ResultScreen>().ShowResult();
        }
        if (textTime < 0)
        {
            correctText.text = " ";
            incorrectText.text = " ";
        }
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
    void RandomArray(GameObject[] items, System.String[] items2, float[]items3)
    {
        // For each spot in the array, pick
        // a random item to swap into that spot.
        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = Random.Range(i, items.Length);
            GameObject temp = items[i];
            items[i] = items[j];
            items[j] = temp;

            System.String temp2 = items2[i];
            items2[i] = items2[j];
            items2[j] = temp2;

            float temp3 = items3[i];
            items3[i] = items3[j];
            items3[j] = temp3;
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

    // Cantidad de ingredientes
    void IngredientCount()
    {
        switch (gameVariables.recipe)
        {
            case 1:
                gameVariables.ingredientsCount = 6;
                break;
            case 2:
                gameVariables.ingredientsCount = 7;
                break;
            case 3:
                gameVariables.ingredientsCount = 6;
                break;
            case 4:
                gameVariables.ingredientsCount = 5;
                break;
            case 5:
                gameVariables.ingredientsCount = 5;
                break;
            default:
                gameVariables.ingredientsCount = 0;
                break;
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

        // Cosas
        AddCount();
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

        // Conteo
        count = 1;
        image2.SetActive(false);
        image3.SetActive(false);
        buttonAdd.GetComponent<Button>().interactable = true;
        buttonSub.GetComponent<Button>().interactable = false;
    }

    // Método que suma o resta los puntos
    public void CheckQuantity()
    {
        // Selectiva para ver si salió bien o no
        if(count - 1 == quantityList[tempPosition])
        {
            UpdatePoints(50, "+50");
            ingredients[tempPosition].SetActive(false);
            AppearIngredients();
            gameVariables.ingredientsCount--;
        }
        else
        {
            UpdatePoints(-25, "-25");
            AppearIngredients();
        }

        // Se oculta la interfaz para seleccionar cantidad
        countUI.SetActive(false);

        // Checando si terminar el juego
        if (gameVariables.ingredientsCount == 0)
        {
            resultScreen.GetComponent<ResultScreen2>().ShowResult();
        }
    }

    // Método para actualizar los puntos
    void UpdatePoints(float points, string text)
    {
        gameVariables.points += points;
        correctText.text = " ";
        incorrectText.text = " ";
        textTime = 2f;

        if (points > 0)
        {
            correctText.text = text;
        }
        else
        {
            incorrectText.text = text;
        }

        if (gameVariables.points < 0)
        {
            pointsText.text = "Puntos: 0";
            gameVariables.points = 0;
        }
        else
        {
            pointsText.text = "Puntos: " + gameVariables.points.ToString();
        }
    }



    //Variables siniestras
    int count = 1;

    // Cosas aún más siniestras!
    public void AddCount()
    {
        buttonSub.GetComponent<Button>().interactable = true;
        switch (count)
        {
            case 1:
                image1.GetComponent<Image>().sprite = Resources.Load<Sprite>(iconList[tempPosition]);
                buttonSub.GetComponent<Button>().interactable = false;
                break;
            case 2:
                image2.GetComponent<Image>().sprite = Resources.Load<Sprite>(iconList[tempPosition]);
                image2.SetActive(true);
                break;
            case 3:
                image3.GetComponent<Image>().sprite = Resources.Load<Sprite>(iconList[tempPosition]);
                image3.SetActive(true);
                buttonAdd.GetComponent<Button>().interactable = false;
                break;
            default:
                break;
        }
        count++;
    }

    // Cosas aún más siniestras!
    public void SubCount()
    {
        buttonAdd.GetComponent<Button>().interactable = true;
        switch (count)
        {
            case 3:
                //image2.GetComponent<Image>().sprite = Resources.Load<Sprite>(iconList[tempPosition]);
                image2.SetActive(false);
                buttonSub.GetComponent<Button>().interactable = false;
                break;
            case 4:
                //image3.GetComponent<Image>().sprite = Resources.Load<Sprite>(iconList[tempPosition]);
                image3.SetActive(false);
                break;
            default:
                break;
        }
        count--;
    }
}
