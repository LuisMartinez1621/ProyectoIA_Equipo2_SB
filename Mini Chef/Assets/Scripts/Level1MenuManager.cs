using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1MenuManager : MonoBehaviour
{
    // Script de las variables
    GameVariables gameVariables;

    // Panel de selección
    public GameObject selectMenu;

    // Panel de los detalles de la receta
    public GameObject recipeDetail;

    // Panel de las instrucciones
    public GameObject instructionPanel1;
    public GameObject instructionPanel2;

    // GameObjects de las imágenes
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;

    // Texto de la pantalla de detalles
    public Text timer;

    // Variable del contador de la pantalla de detalles
    float time;

    // Variable de la pantalla actual
    int screen;

    // Start is called before the first frame update
    void Start()
    {
        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();

        // Se inicializa la variable del tiempo
        screen = 0;
        time = 30f;
        timer.text = time.ToString("f0");
    }

    // Update is called once per frame
    void Update()
    {
        if(screen == 1)
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("f0");
        }
        if(time < 0)
        {
            StartLevel();
        }
    }

    // Elección del primer nivel
    public void SetLevel1Recipe(int recipe)
    {
        // Se establece la receta
        gameVariables.recipe = recipe;
        IngredientCount();

        // Se oculta el menú de selección y se muestra el de detalle
        selectMenu.SetActive(false);
        recipeDetail.SetActive(true);

        // Se muestra los detalles
        ShowDetail(recipe);

        // Cambio de cosas
        screen = 1;
        time = 30f;
    }

    // Cantidad de ingredientes
    void IngredientCount()
    {
        switch(gameVariables.recipe)
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

    // Método que carga la pantalla de los detalles
    public void ShowDetail(int recipe)
    {
        switch(recipe)
        {
            // Sandwich
            case 1:
                image3.SetActive(true);
                image7.SetActive(true);
                SetImage(image1, "Ingredients/Jamon", "Jamón");
                SetImage(image2, "Ingredients/Pan", "Pan");
                SetImage(image3, "Ingredients/Queso", "Queso");
                SetImage(image5, "Ingredients/Mostaza", "Mostaza");
                SetImage(image6, "Ingredients/Mayonesa", "Mayonesa");
                SetImage(image7, "Ingredients/Lechuga", "Lechuga");
                break;

            // Huev0s
            case 2:
                image3.SetActive(true);
                image4.SetActive(true);
                image7.SetActive(true);
                SetImage(image1, "Ingredients/Huevo", "Huevos");
                SetImage(image2, "Ingredients/Leche", "Leche");
                SetImage(image3, "Ingredients/Jamon", "Jamón");
                SetImage(image4, "Ingredients/Mantequilla", "Mantequilla");
                SetImage(image5, "Ingredients/Sal", "Sal");
                SetImage(image6, "Ingredients/Queso", "Queso");
                SetImage(image7, "Ingredients/Pimienta", "Pimienta");
                break;

            // Ensalada de atún
            case 3:
                image7.SetActive(true);
                image8.SetActive(true);
                SetImage(image1, "Ingredients/Atun", "Atún");
                SetImage(image2, "Ingredients/Verduras", "Verduras");
                SetImage(image5, "Ingredients/Pimienta", "Pimienta");
                SetImage(image6, "Ingredients/Mayonesa", "Mayonesa");
                SetImage(image7, "Ingredients/Sal", "Sal");
                SetImage(image8, "Ingredients/Crema", "Crema");
                break;

            // Arroz con leche
            case 4:
                image3.SetActive(true);
                SetImage(image1, "Ingredients/Agua", "Agua");
                SetImage(image2, "Ingredients/Arroz", "Arroz");
                SetImage(image3, "Ingredients/Leche", "Leche");
                SetImage(image5, "Ingredients/Canela", "Canela");
                SetImage(image6, "Ingredients/Pasas", "Pasas");
                break;
            
            // Hotcakes
            case 5:
                image3.SetActive(true);
                SetImage(image1, "Ingredients/Harina", "Harina");
                SetImage(image2, "Ingredients/Leche", "Leche");
                SetImage(image3, "Ingredients/Huevo", "Huevos");
                SetImage(image5, "Ingredients/Mantequilla", "Mantequilla");
                SetImage(image6, "Ingredients/Miel", "Miel");
                break;
        }
    }

    // Método para colocar cosas
    void SetImage(GameObject image, string source, string text)
    {
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>(source);
        image.GetComponentInChildren<Text>().text = text;
    }

    // Método para regresar al menpu de selección
    public void ReturnMenu()
    {
        // Se oculta el menú de detalle y se muestra el de selección
        recipeDetail.SetActive(false);
        selectMenu.SetActive(true);

        Hide();

        // Cosas
        screen = 0;
    }

    // Método para ocultar las cosas
    void Hide()
    {
        image3.SetActive(false);
        image4.SetActive(false);
        image7.SetActive(false);
        image8.SetActive(false);
    }

    // Método para mostrar las primeras instrucciones
    public void ShowInstructions1()
    {
        recipeDetail.SetActive(false);
        instructionPanel1.SetActive(true);
    }

    // Método para mostrar las segundas instrucciones
    public void ShowInstructions2()
    {
        instructionPanel1.SetActive(false);
        instructionPanel2.SetActive(true);
    }

    // Método para cargar el nivel
    public void StartLevel()
    {
        // Se inicia el nivel
        SceneManager.LoadScene("Nivel 1");
    }
}
