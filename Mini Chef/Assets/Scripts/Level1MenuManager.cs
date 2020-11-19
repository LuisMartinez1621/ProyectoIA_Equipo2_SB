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

    // GameObjects de las imágenes
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;

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
        gameVariables.level1Recipe = recipe;
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
        switch(gameVariables.level1Recipe)
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
                image6.SetActive(true);
                SetImage(image1, "Icons/Jamon", "Jamón");
                SetImage(image2, "Icons/Pan", "Pan");
                SetImage(image3, "Icons/Queso", "Queso");
                SetImage(image4, "Icons/Mostaza", "Mostaza");
                SetImage(image5, "Icons/Mayonesa", "Mayonesa");
                SetImage(image6, "Icons/Lechuga", "Lechuga");
                break;

            // Huev0s
            case 2:
                image6.SetActive(true);
                image7.SetActive(true);
                SetImage(image1, "Icons/Huevo", "Huevos");
                SetImage(image2, "Icons/Leche", "Leche");
                SetImage(image3, "Icons/Jamon", "Jamón");
                SetImage(image4, "Icons/Mantequilla", "Mantequilla");
                SetImage(image5, "Icons/Sal", "Sal");
                SetImage(image6, "Icons/Queso", "Queso");
                SetImage(image7, "Icons/Pimienta", "Pimienta");
                break;

            // Ensalada de atún
            case 3:
                image6.SetActive(true);
                SetImage(image1, "Icons/Atun", "Atún");
                SetImage(image2, "Icons/Verduras", "Verduras");
                SetImage(image3, "Icons/Pimienta", "Pimienta");
                SetImage(image4, "Icons/Mayonesa", "Mayonesa");
                SetImage(image5, "Icons/Sal", "Sal");
                SetImage(image6, "Icons/Crema", "Crema");
                break;

            // Arroz con leche
            case 4:
                SetImage(image1, "Icons/Agua", "Agua");
                SetImage(image2, "Icons/Arroz", "Arroz");
                SetImage(image3, "Icons/Leche", "Leche");
                SetImage(image4, "Icons/Canela", "Canela");
                SetImage(image5, "Icons/Pasas", "Pasas");
                break;
            
            // Hotcakes
            case 5:
                SetImage(image1, "Icons/Harina", "Harina");
                SetImage(image2, "Icons/Leche", "Leche");
                SetImage(image3, "Icons/Huevo", "Huevos");
                SetImage(image4, "Icons/Mantequilla", "Mantequilla");
                SetImage(image5, "Icons/Miel", "Miel");
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
        image6.SetActive(false);
        image7.SetActive(false);
    }

    // Método para cargar el nivel
    public void StartLevel()
    {
        // Se inicia el nivel
        SceneManager.LoadScene("Nivel 1");
    }
}
