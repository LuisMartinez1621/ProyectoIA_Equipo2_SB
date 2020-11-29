using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
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
        int recipe = gameVariables.level1Recipe;
        float points = gameVariables.points;

        // 1. 450
        // 2. 550
        // 3. 400
        // 4. 400
        // 5. 400
        switch(recipe)
        {
            case 1:
                CalculateResult(450, points);
                break;

            case 2:
                CalculateResult(550, points);
                break;

            case 3:
                CalculateResult(400, points);
                break;

            case 4:
                CalculateResult(400, points);
                break;

            case 5:
                CalculateResult(400, points);
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
        if (percent < 66f)
        {
            // Mal, una sola estrella
            SetResult("Icons/1Star", points);
        }
        else
        {
            if (percent >= 66f && percent < 100)
            {
                // Bien, dos estrellas
                SetResult("Icons/2Star", points);
            }
            else
            {
                // Excelente, tres estrellas
                SetResult("Icons/3Star", points);
            }
        }
    }

    // Poniendo el resultado
    void SetResult(string source, float points)
    {
        starImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(source);
        resultPoints.text = points.ToString("f0");
    }

    // Regresando al menu
    public void ChangeRecipe()
    {
        gameVariables.points = 0;
        SceneManager.LoadScene("Nivel 1 Menu");
    }
}
