using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen2 : MonoBehaviour
{
    // Referencia a las variables globalisimas
    GameVariables gameVariables;

    // Imagen de las estrellas
    public GameObject starImage;

    // Textbox del puntaje
    public Text resultPoints;

    // Cosas para ocultar
    public GameObject uiPanel;
    public GameObject pauseScreen;
    public GameObject imageTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Mostrando los resultados
    public void ShowResult()
    {
        // Ocultando todo
        gameObject.SetActive(true);
        uiPanel.SetActive(false);
        pauseScreen.SetActive(false);
        imageTarget.SetActive(false);
        Results();
    }

    // Selectiva de cosas
    void Results()
    {
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();
        int recipe = gameVariables.recipe;
        float points = gameVariables.points;

        // 1. 300
        // 2. 350
        // 3. 300
        // 4. 250
        // 5. 250
        switch (recipe)
        {
            case 1:
                CalculateResult(300, points);
                break;

            case 2:
                CalculateResult(350, points);
                break;

            case 3:
                CalculateResult(300, points);
                break;

            case 4:
                CalculateResult(250, points);
                break;

            case 5:
                CalculateResult(250, points);
                break;

            default:
                CalculateResult(100, 0);
                break;
        }
    }

    // Calculando el resultado
    void CalculateResult(float maxPoints, float points)
    {
        // Calculando el porcentaje
        float percent;
        percent = (100f / maxPoints) * points;
        percent = Mathf.Round(percent);

        // Llamando al método para mostrar los resultados dependiendo del porcentaje
        if (percent <= 0)
        {
            SetResult("Misc/0Star", "Necesitas repetir el nivel");
        }
        else
        {
            if (percent > 0 && percent < 60f)
            {
                // Mal, una sola estrella
                SetResult("Misc/1Star", "Necesitas repetir el nivel");
            }
            else
            {
                if (percent >= 60f && percent < 100)
                {
                    // Bien, dos estrellas
                    SetResult("Misc/2Star", "Nivel 2 completado");
                }
                else
                {
                    // Excelente, tres estrellas
                    SetResult("Misc/3Star", "Nivel 2 completado");
                }
            }
        }
    }

    // Poniendo el resultado
    void SetResult(string source, string msg)
    {
        starImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(source);
        resultPoints.text = msg;
    }

    // Regresando al menu principal
    public void ChangeRecipe()
    {
        gameVariables.points = 0;
        SceneManager.LoadScene("RecipeList");
    }

    // Regresando al menu de los niveles
    public void ChangeLevel()
    {
        gameVariables.points = 0;
        SceneManager.LoadScene("LevelSelection");
    }

    // Repitiendo el nivel
    public void RepeatLevel()
    {
        gameVariables.points = 0;

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

        SceneManager.LoadScene("Nivel 2");
    }
}
